namespace CohesionAndCoupling
{
    public interface ICuboid
    {
        double Width { get; }

        double Height { get; }

        double Depth { get; }

        double CalculateVolume();

        double CalculateDiagonalXYZ();

        double CalculateDiagonalXY();

        double CalculateDiagonalXZ();

        double CalculateDiagonalYZ();
    }
}
