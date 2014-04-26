
//Write a program that finds the maximal increasing sequence in an array.
//Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;

class MaxIncreasingSequence
{
    static void Main(string[] args)
    {
        //you can add some numbers to the array to test different scenarios
        int[] numbersArray = new int[] { 23, 45, 34, 35, 25, 56, 57, 59, 100, 90, 92, 95, 96, 97, 98, 99 };

        int startPosition = 0;
        int endPosition = 0;
        int maxCount = 0;

        for (int i = 0; i < numbersArray.Length; i++)
        {
            if (i < numbersArray.Length - 1) //check if we are in the bounds of the array
            {
                if (numbersArray[i] < numbersArray[i+1])
                {
                    int startStatic = i;
                    int start = i;
                    int end = i + 1;
                    int count = 1;
                    while (numbersArray[start] < numbersArray[end]) //check if the next number is bigger
                    {
                        count++; //count the length of the sequence; starts from 1 because to enter the loop we have already found 1 element of the sequence
                        start++;
                        if (end + 1 <= numbersArray.Length - 1) end++; //check if the next element is in the bounds of the array
                        else break;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                        startPosition = startStatic;
                        if (end == numbersArray.Length - 1) endPosition = end;
                        else endPosition = end - 1;
                    }
                }
            }
        }

        //create array to hold the sequence or you can just print it
        int[] increasingSequence = new int[maxCount];
        for (int i = startPosition, k = 0; i <= endPosition; i++, k++)
        {
            increasingSequence[k] = numbersArray[i];
        }

        //print the new array
        Console.Write("The longest increasing sequence is: ");
        foreach (var element in increasingSequence)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}