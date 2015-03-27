

namespace GeometryShapes
{
    public class Square : Shape
    {
        public Square(double sideLength)
            : base(sideLength, sideLength)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width * this.Height;
        }
    }
}
