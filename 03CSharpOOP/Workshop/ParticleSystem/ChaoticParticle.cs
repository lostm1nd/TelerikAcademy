namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChaoticParticle : Particle
    {
        // Fields
        public static readonly char[,] ChaoticParticleImage = { { (char)5 } };

        protected Random randomChaoticGenerator;
        private const int maxSpeedDeviation = 3;

        // Constructor
        public ChaoticParticle(MatrixCoords pos, MatrixCoords speed, Random generator)
            : base(pos, speed)
        {
            this.randomChaoticGenerator = generator;
        }

        // Methods
        public override IEnumerable<Particle> Update()
        {
            this.Speed = GetRandomSpeed();
            return base.Update();
        }

        public override char[,] GetImage()
        {
            return ChaoticParticle.ChaoticParticleImage;
        }

        protected virtual MatrixCoords GetRandomSpeed()
        {
            return new MatrixCoords(this.randomChaoticGenerator.Next(-maxSpeedDeviation, maxSpeedDeviation + 1),
                this.randomChaoticGenerator.Next(-maxSpeedDeviation, maxSpeedDeviation + 1));
        }
    }
}
