namespace GeometryShapes
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract double CalculateSurface();
    }
}
