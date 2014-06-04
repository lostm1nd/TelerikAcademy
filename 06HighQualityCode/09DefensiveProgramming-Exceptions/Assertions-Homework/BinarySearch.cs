namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public static class BinarySearch
    {
        public static int Search<T>(T[] arr, T value) where T : IComparable<T>
        {
            return ExecuteSearch(arr, value, 0, arr.Length - 1);
        }

        private static int ExecuteSearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "Cannot search in an null or empty array.");
            Debug.Assert(startIndex <= endIndex,
                "Start index for binary search should be less or equal to end index.");

            while (startIndex <= endIndex)
            {
                int midIndex = startIndex / 2 + endIndex / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
