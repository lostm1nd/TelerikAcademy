namespace RemoveNumbersWithOddOcurrence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            Dictionary<int, int> numberFrequency = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numberFrequency.ContainsKey(numbers[i]))
                {
                    numberFrequency[numbers[i]] += 1;
                }
                else
                {
                    numberFrequency[numbers[i]] = 1;
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numberFrequency[numbers[i]] % 2 != 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
