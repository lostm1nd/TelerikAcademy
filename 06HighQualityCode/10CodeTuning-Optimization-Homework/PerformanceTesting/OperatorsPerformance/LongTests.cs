namespace OperatorsPerformance
{
    public static class LongTests
    {
        public static void Addition()
        {
            long sum = 1;
            for (int i = 1; i < 100001; i++)
            {
                sum = sum + i;
            }
        }

        public static void Subtraction()
        {
            long subtact = 1;
            for (int i = 1; i < 100001; i++)
            {
                subtact = i - subtact;
            }
        }

        public static void Multiplication()
        {
            long multi = 1;
            for (int i = 1; i < 100001; i++)
            {
                multi = 1 * multi;
            }
        }

        public static void Division()
        {
            long divide = 1;
            for (int i = 1; i < 100001; i++)
            {
                divide = i / divide;
            }
        }
    }
}
