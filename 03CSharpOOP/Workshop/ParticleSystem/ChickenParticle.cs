namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        // Fields
        public static readonly char[,] ChickenParticleImage = { { 'F' } };

        private static readonly MatrixCoords Stop = new MatrixCoords(0, 0);
        private const double ChanceToStop = 0.4;

        // Constructor
        public ChickenParticle(MatrixCoords pos, MatrixCoords speed, Random generator)
            : base(pos, speed, generator)
        {
        }

        //Methods
        public override char[,] GetImage()
        {
            return ChickenParticle.ChickenParticleImage;
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.Speed.Equals(ChickenParticle.Stop))
            {
                IEnumerable<Particle> baseParticles = base.Update();
                List<Particle> newChickens = new List<Particle>(baseParticles);
                newChickens.Add(new ChickenParticle(this.Position, ChickenParticle.Stop, this.randomChaoticGenerator));
                return newChickens;
            }

            return base.Update();
        }

        protected override MatrixCoords GetRandomSpeed()
        {
            if (this.randomChaoticGenerator.NextDouble() <= ChickenParticle.ChanceToStop)
            {
                return ChickenParticle.Stop;
            }
            else
            {
                return base.GetRandomSpeed();
            }
        }
    }
}
