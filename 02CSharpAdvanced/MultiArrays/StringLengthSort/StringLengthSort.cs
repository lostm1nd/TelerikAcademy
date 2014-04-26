//You are given an array of strings.
//Write a method that sorts the array by the
//length of its elements (the number of characters composing them).

using System;

class StringLengthSort
{
    //keep it clean with a method for the sorting alhorithm
    //the algorithm is stable and keeps the relative places of the elements
    static void StringSort(string[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            string tempString = array[i];
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[i].Length > array[j].Length)
                {
                    array[i] = array[j];
                    array[j] = tempString;
                    tempString = array[i];
                }
            }
        }
    }

    static void Main()
    {
        string[] arrayToSort = new string[]
        {
            "you",
            "must",
            "be",
            "fucking",
            "kidding",
            "me",
            "it",
            "is",
            "Christmas",
            "Eve"
        };

        string unsorted = string.Join(" ", arrayToSort);
        Console.WriteLine("This is the unsorted array:");
        Console.WriteLine(unsorted);
        Console.WriteLine();

        Console.WriteLine("Array after subjected to selection sort");
        StringSort(arrayToSort);
        string sorted = string.Join(" ", arrayToSort);
        Console.WriteLine(sorted);
        Console.WriteLine();
    }
}