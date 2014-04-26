
//Write a program that finds the sequence of maximal sum in given array.
//Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}

using System;

class MaxSumSequence
{
    static void Main()
    {
        //initialize and print the array
        int[] randomArray = { 2, 23, -1, 3, 3, 4, -70, 1, -5, 5, 9, 1, -2 };
        Console.WriteLine("We search for max sum in the following array:");
        for (int i = 0; i < randomArray.Length; i++)
        {
            Console.Write(randomArray[i] + " ");
        }
        Console.WriteLine("\n");

        //calculate max sum, Kadane's algorithm
        int currentSum = 0;
        int maxSum = int.MinValue;
        int startIndex = 0;
        int endIndex = 0;
        int tempIndex = 0;

        for (int i = 0; i < randomArray.Length; i++)
        {
            currentSum += randomArray[i];

            if (currentSum <= 0)
            {
                currentSum = 0;
                tempIndex = i + 1;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = tempIndex;
                endIndex = i;
            }
        }

        //output sequence and max sum
        Console.WriteLine("The sequence with maximun sum is:");
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(randomArray[i] + " ");
        }
        Console.WriteLine("= {0}\n", maxSum);
    }
}