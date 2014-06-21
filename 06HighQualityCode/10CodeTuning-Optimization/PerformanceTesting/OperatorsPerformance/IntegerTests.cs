namespace OperatorsPerformance
{
    public static class IntegerTests
    {
        public static void Addition()
        {
            int sum = 1;
            for (int i = 1; i < 100001; i++)
            {
                sum = sum + i;
            }
        }

        public static void Subtraction()
        {
            int subtact = 1;
            for (int i = 1; i < 100001; i++)
            {
                subtact = i - subtact;
            }
        }

        public static void Multiplication()
        {
            int multi = 1;
            for (int i = 1; i < 100001; i++)
            {
                multi = 1 * multi;
            }
        }

        public static void Division()
        {
            int divide = 1;
            for (int i = 1; i < 100001; i++)
            {
                divide = i / divide;
            }
        }
    }
}
