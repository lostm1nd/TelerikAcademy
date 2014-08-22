namespace BinaryPasswords
{
    using System;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int freeSlots = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    freeSlots += 1;
                }
            }

            Console.WriteLine(NumberToThePower(2, freeSlots));
        }

        static long NumberToThePower(int number, int power)
        {
            long result = 1;
            for (int i = 0; i < power; i++)
            {
                result = result * number;
            }

            return result;
        }
    }
}