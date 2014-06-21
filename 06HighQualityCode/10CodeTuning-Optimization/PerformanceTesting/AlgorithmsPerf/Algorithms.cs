namespace AlgorithmsPerf
{
    using System;

    public static class Algorithms
    {
        public static void InsertionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i;

                while (index > 0 && array[index-1].CompareTo(array[index]) > 0)
                {
                    // swap them values
                    T swap = array[index - 1];
                    array[index - 1] = array[index];
                    array[index] = swap;

                    index--;
                }
            }
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minValueIndex = i;
                for (int k = i+1; k < array.Length; k++)
                {
                    if (array[minValueIndex].CompareTo(array[k]) > 0)
                    {
                        minValueIndex = k;
                    }
                }
                // swap the values
                T swap = array[i];
                array[i] = array[minValueIndex];
                array[minValueIndex] = swap;
            }
        }

        public static void QuickSort<T>(T[] array, int start, int end) where T : IComparable
        {
            if (start < end)
            {
                T swap;
                int pivotIndex = end;
                int leftPart = start - 1;
                int rightPart = end;

                do
                {
                    do
                    {
                        leftPart += 1;
                    } while (array[leftPart].CompareTo(array[pivotIndex]) < 0);

                    do
                    {
                        rightPart -= 1;
                    } while (array[rightPart].CompareTo(array[pivotIndex]) > 0 && rightPart > start);

                    if (leftPart < rightPart)
                    {
                        swap = array[leftPart];
                        array[leftPart] = array[rightPart];
                        array[rightPart] = swap;
                    }

                } while (leftPart < rightPart);

                // put the pivot at the right place
                swap = array[leftPart];
                array[leftPart] = array[pivotIndex];
                array[pivotIndex] = swap;

                QuickSort(array, start, leftPart - 1);
                QuickSort(array, leftPart + 1, end);
            }
        }

        //private static int Partition<T>(T[] array, int start, int end) where T : IComparable
        //{
        //    int left = start;
        //    int right = end - 1;
        //    int pivotIndex = end;
        //    T pivot = array[pivotIndex];

        //    do
        //    {


        //    } while (left < right);
        //}
    }
}
