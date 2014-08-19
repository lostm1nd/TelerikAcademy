namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            int collectionSize = collection.Count;

            if (collectionSize <= 1)
            {
                return;
            }

            int middle = collectionSize / 2;
            IList<T> left = new List<T>(middle);
            IList<T> right = new List<T>(collectionSize - middle);

            for (int i = 0; i < collectionSize; i++)
            {
                if (i < middle)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            MergeSort(left);
            MergeSort(right);
            Merge(left, right, collection);

            left = null;
            right = null;
        }

        private void Merge(IList<T> left, IList<T> right, IList<T> collection)
        {
            int leftSize = left.Count;
            int rightSize = right.Count;
            int leftIndex = 0;
            int rightIndex = 0;
            int filledIndex = 0;

            while (leftIndex < leftSize && rightIndex < rightSize)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    collection[filledIndex] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    collection[filledIndex] = right[rightIndex];
                    rightIndex++;
                }

                filledIndex++;
            }

            while (leftIndex < leftSize)
            {
                collection[filledIndex] = left[leftIndex];
                leftIndex++;
                filledIndex++;
            }

            while (rightIndex < rightSize)
            {
                collection[filledIndex] = right[rightIndex];
                rightIndex++;
                filledIndex++;
            }
        }
    }
}
