namespace OperatorsPerformance
{
    public static class DoubleTests
    {
        public static void Addition()
        {
            double sum = 1;
            for (int i = 1; i < 100001; i++)
            {
                sum = sum + i;
            }
        }

        public static void Subtraction()
        {
            double subtact = 1;
            for (int i = 1; i < 100001; i++)
            {
                subtact = i - subtact;
            }
        }

        public static void Multiplication()
        {
            double multi = 1;
            for (int i = 1; i < 100001; i++)
            {
                multi = 1 * multi;
            }
        }

        public static void Division()
        {
            double divide = 1;
            for (int i = 1; i < 100001; i++)
            {
                divide = i / divide;
            }
        }
    }
}
