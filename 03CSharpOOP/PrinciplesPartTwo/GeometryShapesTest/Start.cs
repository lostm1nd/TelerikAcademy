namespace GeometryShapesTest
{
    using System;
    using GeometryShapes;

    public class Start
    {
        public static void Main()
        {
            var shapes = new Shape[]
            {
                new Rectangle(23.12, 12.5),
                new Triangle(11.2, 5.4),
                new Square(4.4)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
