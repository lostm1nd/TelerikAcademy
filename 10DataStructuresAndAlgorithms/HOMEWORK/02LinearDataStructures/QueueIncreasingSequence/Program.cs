namespace QueueIncreasingSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter starting number: ");

            int start = int.Parse(Console.ReadLine());

            Queue<long> sequence = new Queue<long>();
            sequence.Enqueue(start);

            int repetitions = 50;

            while (repetitions > 0)
            {
                long currentNumber = sequence.Dequeue();

                sequence.Enqueue(currentNumber + 1);
                sequence.Enqueue(2 * currentNumber + 1);
                sequence.Enqueue(currentNumber + 2);

                Console.WriteLine(currentNumber);

                repetitions--;
            }
        }
    }
}
