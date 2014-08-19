namespace SumAndAverageOfList
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
                int currentNumber;

                if (int.TryParse(input, out currentNumber))
                {
                    numbers.Add(currentNumber);
                }

                input = Console.ReadLine();
            }

            long sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            long average = sum / numbers.Count;

            Console.WriteLine("Sum: " + sum);
            Console.WriteLine("Average: " + average);
        }
    }
}
