namespace OperatorsPerformance
{
    public static class FloatTests
    {
        public static void Addition()
        {
            float sum = 1;
            for (int i = 1; i < 100001; i++)
            {
                sum = sum + i;
            }
        }

        public static void Subtraction()
        {
            float subtact = 1;
            for (int i = 1; i < 100001; i++)
            {
                subtact = i - subtact;
            }
        }

        public static void Multiplication()
        {
            float multi = 1;
            for (int i = 1; i < 100001; i++)
            {
                multi = 1 * multi;
            }
        }

        public static void Division()
        {
            float divide = 1;
            for (int i = 1; i < 100001; i++)
            {
                divide = i / divide;
            }
        }
    }
}
