namespace ParticleSystem
{
    class ParticleRepeller : Particle
    {
        // Fields
        public static readonly char[,] ParticleRepellerImage = { { 'R' } };

        // Constructor
        public ParticleRepeller(MatrixCoords pos, MatrixCoords speed, int repelRadius)
            : base(pos, speed)
        {
            this.RepelRadius = repelRadius;
        }

        // Fields
        public int RepelRadius { get; private set; }

        // Methods
        public override char[,] GetImage()
        {
            return ParticleRepeller.ParticleRepellerImage;
        }
    }
}
