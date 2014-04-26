
//Write a program that sorts an array of
//integers using the merge sort algorithm.

using System;

class MergeSortManual
{
    //implement the merge sort algorithm
    static void MergeSort(int[] array)
    {
        int arrayLength = array.Length;

        if (arrayLength < 2)
            return;

        int arrayMiddle = arrayLength / 2;
        //create two new arrays and populate them
        int[] leftArray = new int[arrayMiddle];
        int[] rightArray = new int[arrayLength - arrayMiddle];

        for (int i = 0; i < leftArray.Length; i++)
        {
            leftArray[i] = array[i];
        }

        for (int i = arrayMiddle; i < arrayLength; i++)
        {
            rightArray[i - arrayMiddle] = array[i];
        }

        MergeSort(leftArray); //recursive call for left side
        MergeSort(rightArray); //recursive call for right side
        Merge(array, leftArray, rightArray); //call the merge method
    }

    //merging method
    static void Merge(int[] mergingArray, int[] leftArray, int[] rightArray)
    {
        int elementsLeftArray = leftArray.Length;
        int elementsRightArray = rightArray.Length;

        int leftArrayPos = 0;
        int rightArrayPos = 0;
        int mergingArrayPos = 0;

        while (leftArrayPos < elementsLeftArray && rightArrayPos < elementsRightArray) //elements in both arrays
        {
            if (leftArray[leftArrayPos] <= rightArray[rightArrayPos])
            {
                mergingArray[mergingArrayPos] = leftArray[leftArrayPos];
                leftArrayPos++;
            }
            else if (rightArray[rightArrayPos] <= leftArray[leftArrayPos])
            {
                mergingArray[mergingArrayPos] = rightArray[rightArrayPos];
                rightArrayPos++;
            }
            mergingArrayPos++;
        }

        while (leftArrayPos < elementsLeftArray) //elements only in left array
        {
            mergingArray[mergingArrayPos] = leftArray[leftArrayPos];
            mergingArrayPos++;
            leftArrayPos++;
        }

        while (rightArrayPos < elementsRightArray) //elements only in right array
        {
            mergingArray[mergingArrayPos] = rightArray[rightArrayPos];
            mergingArrayPos++;
            rightArrayPos++;
        }
    }

    static void Main()
    {
        //initialize array and print it
        int[] unsortedArray = { 9, 1, 0, 2, 4, 8, 0, 2, 6, 5, 7, 3, 1 };
        Console.WriteLine("Unsorted array: ");
        foreach (var item in unsortedArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        //call the merge sort algorithm
        MergeSort(unsortedArray);

        //print the array again to check if it is sorted
        Console.WriteLine("Array after Merge-sort algorith: ");
        foreach (var item in unsortedArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}