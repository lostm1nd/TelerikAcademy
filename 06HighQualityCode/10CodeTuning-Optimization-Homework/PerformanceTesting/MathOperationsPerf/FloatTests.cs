namespace MathOperationsPerf
{
    using System;

    public static class FloatTests
    {
        public static void SquareRoot()
        {
            float sqrt = 0;
            for (int i = 1; i < 100001; i++)
            {
                sqrt = (float) Math.Sqrt(i);
            }
        }

        public static void NaturalLogarithm()
        {
            float log = 0;
            for (int i = 1; i < 100001; i++)
            {
                log = (float) Math.Log(i);
            }
        }

        public static void Sinus()
        {
            float sin = 0;
            for (int i = 1; i < 100001; i++)
            {
                sin = (float)Math.Sin(i);
            }
        }
    }
}
