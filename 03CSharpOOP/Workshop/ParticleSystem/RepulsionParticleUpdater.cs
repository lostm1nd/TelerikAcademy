namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class RepulsionParticleUpdater : ParticleUpdater
    {
        // Fields
        private List<Particle> currentTickPartciles = new List<Particle>();
        private List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        // Methods
        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repeller = p as ParticleRepeller;

            if (repeller != null)
            {
                this.currentTickRepellers.Add(repeller);
            }
            else
            {
                this.currentTickPartciles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.currentTickRepellers)
            {
                foreach (var particle in this.currentTickPartciles)
                {
                    if (this.IsParticleInRadius(particle, repeller))
                    {
                        particle.Accelerate(this.InvertSpeed(particle));
                    }
                }
            }

            this.currentTickPartciles.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }

        private MatrixCoords InvertSpeed(Particle particle)
        {
            int invertedSpeedX = -2 * particle.Speed.Row;
            int invertedSpeedY = -2 * particle.Speed.Col;

            return new MatrixCoords(invertedSpeedX, invertedSpeedY);
        }

        private bool IsParticleInRadius(Particle particle, ParticleRepeller repeller)
        {
            if (particle.Position.Row > repeller.Position.Row - repeller.RepelRadius 
                && particle.Position.Row < repeller.Position.Row + repeller.RepelRadius
                && particle.Position.Col > repeller.Position.Col - repeller.RepelRadius
                && particle.Position.Col < repeller.Position.Col + repeller.RepelRadius)
            {
                return true;
            }

            return false;
        }
    }
}
