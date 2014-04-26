
//Write a program that reads an array of integers and removes
//from it a minimal number of elements in such way that the
//remaining array is sorted in increasing order. Print the remaining sorted array.
//Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
using System;
using System.Linq;
using System.Text;

class LIS
{
    static void Main()
    {
        //read input data
        //Console.WriteLine("Enter array size:");
        //int size = int.Parse(Console.ReadLine());
        //Console.WriteLine("Enter elements of the array:");
        //int[] array = new int[size];
        //for (int i = 0; i < array.Length; i++)
        //{
        //    array[i] = int.Parse(Console.ReadLine());
        //}

        int[] array = { 6, 1, 4, 3, 0, 3, 4, 6, 5 };
        int[] lis = new int[array.Length];

        //solution
        for (int i = 0; i < array.Length; i++)
        {
            lis[i] = 1;
            for (int k = 0; k < i; k++)
            {
                if (array[k] <= array[i] && lis[k] + 1 > lis[i])
                {
                    lis[i] = lis[k] + 1;
                }
            }            
        }
        
        //print
        Console.WriteLine("The longest increasing sequence is of length {0}", lis.Max());
    }
}