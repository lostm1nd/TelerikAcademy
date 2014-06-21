namespace MathOperationsPerf
{
    using System;

    public static class DoubleTests
    {
        public static void SquareRoot()
        {
            double sqrt = 0;
            for (int i = 1; i < 100001; i++)
            {
                sqrt = Math.Sqrt(i);
            }
        }

        public static void NaturalLogarithm()
        {
            double log = 0;
            for (int i = 1; i < 100001; i++)
            {
                log = Math.Log(i);
            }
        }

        public static void Sinus()
        {
            double sin = 0;
            for (int i = 1; i < 100001; i++)
            {
                sin = Math.Sin(i);
            }
        }
    }
}
