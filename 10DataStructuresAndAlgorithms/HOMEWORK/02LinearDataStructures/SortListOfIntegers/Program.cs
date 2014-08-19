namespace SortListOfIntegers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int currentNumber = 0;

                if (int.TryParse(input, out currentNumber))
                {
                    numbers.Add(currentNumber);
                }

                input = Console.ReadLine();
            }

            numbers.Sort();

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
