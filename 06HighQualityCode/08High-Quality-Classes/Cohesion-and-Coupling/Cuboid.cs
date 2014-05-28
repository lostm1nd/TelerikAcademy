namespace CohesionAndCoupling
{
    using System;

    public class Cuboid : ICuboid
    {
        // Fields
        private double width;
        private double height;
        private double depth;

        // Constructor
        public Cuboid(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        // Properties
        public double Width
        {
            get 
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The width of the cuboid must be a positive number.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get 
            {
                return this.height; 
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height of the cuboid must be a positive number.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get 
            {
                return this.depth; 
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The depth of the cuboid must be a positive number.");
                }

                this.depth = value;
            }
        }

        // Methods
        public double CalculateVolume()
        {
            double volume = this.width * this.height * this.depth;
            return volume;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = this.width * this.width + this.height * this.height + this.depth * this.depth;
            distance = Math.Sqrt(distance);
            return distance;
        }

        public double CalculateDiagonalXY()
        {
            double distance = this.width * this.width + this.height * this.height;
            distance = Math.Sqrt(distance);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            double distance = this.width * this.width + this.depth * this.depth;
            distance = Math.Sqrt(distance);
            return distance;
        }

        public double CalculateDiagonalYZ()
        {
            double distance = this.height * this.height + this.depth * this.depth;
            distance = Math.Sqrt(distance);
            return distance;
        }
    }
}
