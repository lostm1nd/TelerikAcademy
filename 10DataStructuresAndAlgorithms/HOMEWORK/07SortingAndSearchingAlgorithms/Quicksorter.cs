namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(0, collection.Count-1, collection);
        }

        private void QuickSort(int left, int right, IList<T> collection)
        {
            int leftIndex = left;
            int rightIndex = right;
            int middle = leftIndex / 2 + rightIndex / 2;
            T pivot = collection[middle];

            while (leftIndex <= rightIndex)
            {
                while (collection[leftIndex].CompareTo(pivot) < 0)
                {
                    leftIndex++;
                }

                while (collection[rightIndex].CompareTo(pivot) > 0)
                {
                    rightIndex--;
                }

                if (leftIndex <= rightIndex)
                {
                    T swap = collection[leftIndex];
                    collection[leftIndex] = collection[rightIndex];
                    collection[rightIndex] = swap;
                    leftIndex++;
                    rightIndex--;
                }
            }

            if (left < rightIndex)
            {
                QuickSort(left, rightIndex, collection);
            }

            if (leftIndex < right)
            {
                QuickSort(leftIndex, right, collection);
            }
        }
    }
}
