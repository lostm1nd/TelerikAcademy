namespace MathOperationsPerf
{
    using System;

    public static class DecimalTests
    {
        public static void SquareRoot()
        {
            decimal sqrt = 0;
            for (int i = 1; i < 100001; i++)
            {
                sqrt = (decimal)Math.Sqrt(i);
            }
        }

        public static void NaturalLogarithm()
        {
            decimal log = 0;
            for (int i = 1; i < 100001; i++)
            {
                log = (decimal)Math.Log(i);
            }
        }

        public static void Sinus()
        {
            decimal sin = 0;
            for (int i = 1; i < 100001; i++)
            {
                sin = (decimal)Math.Sin(i);
            }
        }
    }
}
