namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var storedItem in this.items)
            {
                if (storedItem.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count;

            while (left <= right)
            {
                int middle = left / 2 + right / 2;
                if (item.CompareTo(this.items[middle]) == 0)
                {
                    return true;
                }
                else if (item.CompareTo(this.items[middle]) < 0)
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            for (int i = this.items.Count - 1; i > 0; i--)
            {
                int random = Randomizer.Next(0, i);
                T swap = this.items[i];
                this.items[i] = this.items[random];
                this.items[random] = swap;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}