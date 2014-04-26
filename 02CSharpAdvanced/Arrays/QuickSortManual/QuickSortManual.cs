
//Write a program that sorts an array of
//strings using the quick sort algorithm.
using System;
using System.Collections.Generic;

class QuickSortManual
{
    static void StringSwap(ref string a, ref string b)
    {
        string temp = a;
        a = b;
        b = temp;
    }

    static int Partition(string[] array, int startIndex, int endIndex)
    {
        string pivot = array[endIndex];
        int pivotIndex = startIndex;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (array[i].CompareTo(pivot) < 0)
            {
                StringSwap(ref array[i], ref array[pivotIndex]);
                pivotIndex++;                
            }
        }
        StringSwap(ref array[pivotIndex], ref array[endIndex]);

        return pivotIndex;
    }

    static void QuickSortAlgorithm(string[] array, int startIndex, int endIndex)
    {
        if (startIndex >= endIndex) return;

        int pivotIndex = Partition(array, startIndex, endIndex);
        QuickSortAlgorithm(array, startIndex, pivotIndex - 1);
        QuickSortAlgorithm(array, pivotIndex + 1, endIndex);

    }

    static void Main()
    {
        string[] unsortedArray = { "b", "e", "f", "z", "j", "l", "o", "m", "g", "a", "y" };
        string unsorted = string.Join(", ", unsortedArray);
        Console.WriteLine("This is the unsorted array: " + unsorted);

        QuickSortAlgorithm(unsortedArray, 0, unsortedArray.Length - 1);

        string sorted = string.Join(", ", unsortedArray);
        Console.WriteLine("This is the sorted array: " + sorted);
    }
}