namespace LongestSubsequenceOfEqualElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 3, -2, 4, 5, 1, -2, 3, 6, -2, 2, 3, 5, -2, 7, 10, -2, 22, 11, 2, 3, 4, -2, 3 };

            numbers.Sort();

            List<int> longestSequenceOfEqualElements = FindLongestEqualSequence(numbers);

            Console.WriteLine(string.Join(", ", longestSequenceOfEqualElements));
        }

        private static List<int> FindLongestEqualSequence(List<int> numbers)
        {
            int sequenceStartIndex = 0;
            int maxSequenceCount = 1;
            int currentSequenceCount = 1;
            int currentNumber = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == currentNumber)
                {
                    currentSequenceCount++;
                }
                else
                {
                    if (currentSequenceCount > maxSequenceCount)
                    {
                        maxSequenceCount = currentSequenceCount;
                        sequenceStartIndex = i - currentSequenceCount;
                    }

                    currentNumber = numbers[i];
                    currentSequenceCount = 1;
                }
            }

            List<int> longestSequenceOfEqualElements = new List<int>();
            for (int i = sequenceStartIndex; i < sequenceStartIndex + maxSequenceCount; i++)
            {
                longestSequenceOfEqualElements.Add(numbers[i]);
            }
            return longestSequenceOfEqualElements;
        }
    }
}
