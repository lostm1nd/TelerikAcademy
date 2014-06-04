namespace Assertions_Homework
{
    using System;
    using System.Diagnostics;

    public static class SelectionSort
    {
        public static void Sort<T>(T[] arr) where T : IComparable<T>
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null && arr.Length > 0, "The array cannot be null or empty.");
            Debug.Assert(startIndex <= endIndex, "Start index cannot be greater than end index.");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }
            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;

            x = y;
            Debug.Assert(x.Equals(y), "Changing the value of the numbers failed.");

            y = oldX;
            Debug.Assert(y.Equals(oldX), "Changing the value of the numbers failed.");
            
        }
    }
}
