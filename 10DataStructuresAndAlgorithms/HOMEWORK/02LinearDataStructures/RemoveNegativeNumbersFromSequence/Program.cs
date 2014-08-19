namespace RemoveNegativeNumbersFromSequence
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 19, -10, 12, -6, -3, 34, -2, 5 };

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
