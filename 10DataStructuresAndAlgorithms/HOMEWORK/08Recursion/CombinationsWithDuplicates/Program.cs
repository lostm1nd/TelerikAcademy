namespace CombinationsWithDuplicates
{
    using System;

    class Program
    {
        static void Main()
        {
            int n = 4;
            int k = 2;

            GenerateCombinations(n, k);
        }

        private static void GenerateCombinations(int n, int k)
        {
            int[] combinations = new int[k];

            GetCombinations(n, 0, combinations);
        }

        // The solution where no duplicates are allowed is just
        // to change the condition in the for loop to be true
        // when (index == 0 || i > combination[index-1])
        private static void GetCombinations(int maxNumber, int index, int[] combinations)
        {
            if (index == combinations.Length)
            {
                Console.WriteLine("(" + string.Join(" ", combinations) + ")");
                return;
            }

            for (int i = 1; i <= maxNumber; i++)
            {
                if (index == 0 || i >= combinations[index - 1])
                {
                    combinations[index] = i;
                    GetCombinations(maxNumber, index + 1, combinations);
                }
            }
        }
    }
}