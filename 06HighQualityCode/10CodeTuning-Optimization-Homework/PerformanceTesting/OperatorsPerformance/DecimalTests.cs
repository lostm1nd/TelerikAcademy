namespace OperatorsPerformance
{
    public static class DecimalTests
    {
        public static void Addition()
        {
            decimal sum = 1;
            for (int i = 1; i < 100001; i++)
            {
                sum = sum + i;
            }
        }

        public static void Subtraction()
        {
            decimal subtact = 1;
            for (int i = 1; i < 100001; i++)
            {
                subtact = i - subtact;
            }
        }

        public static void Multiplication()
        {
            decimal multi = 1;
            for (int i = 1; i < 100001; i++)
            {
                multi = 1 * multi;
            }
        }

        public static void Division()
        {
            decimal divide = 1;
            for (int i = 1; i < 100001; i++)
            {
                divide = i / divide;
            }
        }
    }
}
