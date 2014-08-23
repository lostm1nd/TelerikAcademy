namespace RecursiveNestedLoops
{
    using System;

    class Program
    {
        static void Main()
        {
            SimulateNestedLoops(3);
        }

        private static void SimulateNestedLoops(int loopsCount)
        {
            int[] numbers = new int[loopsCount];

            GeneratePermutations(0, loopsCount, numbers);
        }

        private static void GeneratePermutations(int index, int loopsCount, int[] numbers)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int i = 1; i <= loopsCount; i++)
            {
                numbers[index] = i;
                GeneratePermutations(index + 1, loopsCount, numbers);
            }
        }
    }
}
