using System;
using System.Collections.Generic;
using System.Text;

public static class Utils
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("The array cannot be null.");
        }

        if (startIndex < 0 || startIndex >= arr.Length)
        {
            throw new IndexOutOfRangeException("Starting index is out of the array.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            // allow the count to be more than the elements
            // and take all the elements till the end
            // when the index is out of the array
            // break the loop
            if (i >= arr.Length)
            {
                break;
            }

            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("The string cannot be null");
        }

        if (count > str.Length)
        {
            return str;
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool IsNumberPrime(int number)
    {
        if (number < 2)
        {
            throw new ArgumentException("Prime numbers are positive integers larger than 2 that have no divisors than itself.");
        }

        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}
