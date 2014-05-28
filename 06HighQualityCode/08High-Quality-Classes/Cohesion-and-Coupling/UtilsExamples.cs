namespace CohesionAndCoupling
{
    using System;

    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                GeometryUtils.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            int width = 3;
            int height = 4;
            int depth = 5;
            Cuboid cuboid = new Cuboid(width, height, depth);

            Console.WriteLine("Volume = {0:f2}", cuboid.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", cuboid.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", cuboid.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", cuboid.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", cuboid.CalculateDiagonalYZ());
        }
    }
}
