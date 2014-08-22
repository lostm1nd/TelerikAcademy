namespace ColorBalls
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Dictionary<char, int> balls = new Dictionary<char, int>();

            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (balls.ContainsKey(input[i]))
                {
                    balls[input[i]] += 1;
                }
                else
                {
                    balls[input[i]] = 1;
                }
            }

            BigInteger answer = CalcFactorial(input.Length);
            foreach (var pair in balls)
            {
                answer /= CalcFactorial(pair.Value);
            }

            Console.WriteLine(answer);
        }

        static BigInteger CalcFactorial(int number)
        {
            BigInteger result = 1;
            for (int i = 1; i <= number; i++)
            {
                result = result * i;
            }

            return result;
        }
    }
}