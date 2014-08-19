namespace NumberOccurrence
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] numbers = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2, 5, 6, 1, 3, 4, 6, 2, 4 };

            int[] occurrence = new int[1001];

            for (int i = 0; i < numbers.Length; i++)
            {
                occurrence[numbers[i]] += 1;
            }

            for (int i = 1; i < occurrence.Length; i++)
            {
                if (occurrence[i] != 0)
                {
                    Console.WriteLine("Number {0} -> {1} times", i, occurrence[i]);
                }
            }
        }
    }
}
