namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static HashSet<int> allPermutations = new HashSet<int>();

        static void Main()
        {
            int numberCount = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberCount];
            for (int i = 0; i < numberCount; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            GeneratePermutations(0, new int[numberCount], numbers, new bool[numberCount]);

            Console.WriteLine(FindNumberWithMinimumDivisors());
        }

        private static int FindNumberWithMinimumDivisors()
        {
            int minDivisors = int.MaxValue;
            int numberWithMinDivisors = 0;
            foreach (var permutation in allPermutations)
            {
                int currentNumberDivisors = 0;
                for (int i = 1; i <= permutation; i++)
                {
                    if (permutation % i == 0)
                    {
                        currentNumberDivisors += 1;
                    }
                }

                if (currentNumberDivisors < minDivisors ||
                    (currentNumberDivisors == minDivisors && permutation < numberWithMinDivisors))
                {
                    minDivisors = currentNumberDivisors;
                    numberWithMinDivisors = permutation;
                }
            }

            return numberWithMinDivisors;
        }

        static void GeneratePermutations(int index, int[] permutation, int[] numbers, bool[] used)
        {
            if (index == permutation.Length)
            {
                SavePermutation(permutation);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if(!used[i])
                {
                    permutation[index] = numbers[i];
                    used[i] = true;
                    GeneratePermutations(index + 1, permutation, numbers, used);
                    used[i] = false;
                }
            }
        }

        private static void SavePermutation(int[] permutation)
        {
            sb.Clear();
            for (int i = 0; i < permutation.Length; i++)
            {
                sb.Append(permutation[i]);
            }

            allPermutations.Add(int.Parse(sb.ToString()));
        }
    }
}