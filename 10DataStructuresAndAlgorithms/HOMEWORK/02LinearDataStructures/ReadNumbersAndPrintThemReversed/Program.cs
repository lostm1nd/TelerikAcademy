namespace ReadNumbersAndPrintThemReversed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Stack<int> numbers = new Stack<int>();

            string input = Console.ReadLine();

            while (input != string.Empty)
            {
                int currentNumber = 0;

                if (int.TryParse(input, out currentNumber))
                {
                    numbers.Push(currentNumber);
                }

                input = Console.ReadLine();
            }

            while (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
