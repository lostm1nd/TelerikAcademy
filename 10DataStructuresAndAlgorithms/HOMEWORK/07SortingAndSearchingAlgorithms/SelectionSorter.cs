namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                int indexOfSmallest = i;
                for (int j = i; j < collection.Count; j++)
                {
                    if (collection[indexOfSmallest].CompareTo(collection[j]) > 0)
                    {
                        indexOfSmallest = j;
                    }
                }

                T swap = collection[i];
                collection[i] = collection[indexOfSmallest];
                collection[indexOfSmallest] = swap;
            }
        }
    }
}
