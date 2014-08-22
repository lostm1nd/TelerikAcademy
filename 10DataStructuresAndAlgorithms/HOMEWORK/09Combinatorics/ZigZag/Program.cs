namespace ZigZag
{
    using System;

    class Program
    {
        static int sequencesCount = 0;

        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int endNumber = int.Parse(input[0]);
            int sequenceSize = int.Parse(input[1]);

            int[] numbers = new int[endNumber];
            for (int i = 0; i < endNumber; i++)
            {
                numbers[i] = i;
            }

            int[] sequence = new int[sequenceSize];
            GenerateZigZagSequence(0, sequence, numbers, new bool[endNumber], false);
            Console.WriteLine(sequencesCount);
        }

        private static void GenerateZigZagSequence(int index, int[] sequence, int[] numbers, bool[] used, bool isPrevBigger)
        {
            if (index == sequence.Length)
            {
                sequencesCount += 1;
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (index == 0)
                {
                    sequence[index] = numbers[i];
                    used[i] = true;
                    GenerateZigZagSequence(index+1, sequence, numbers, used, !isPrevBigger);
                    used[i] = false;
                }
                else if (isPrevBigger && sequence[index - 1] > numbers[i] && !used[i])
                {
                    sequence[index] = numbers[i];
                    used[i] = true;
                    GenerateZigZagSequence(index + 1, sequence, numbers, used, !isPrevBigger);
                    used[i] = false;
                }
                else if (!isPrevBigger && sequence[index - 1] < numbers[i] && !used[i])
                {
                    sequence[index] = numbers[i];
                    used[i] = true;
                    GenerateZigZagSequence(index + 1, sequence, numbers, used, !isPrevBigger);
                    used[i] = false;
                }
            }
        }
    }
}