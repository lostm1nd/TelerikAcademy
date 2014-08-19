namespace HashedSet
{
    using System;

    using HashTable;
    using System.Collections.Generic;

    public class Set<T> :  IEnumerable<T>
    {
        private readonly Hash<T, bool> set;

        public Set()
        {
            this.set = new Hash<T, bool>();
        }

        public Set(int capacity)
        {
            this.set = new Hash<T, bool>(capacity);
        }

        public int Count
        {
            get
            {
                return this.set.Count;
            }
        }

        public void Add(T element)
        {
            this.set.Add(element, true);
        }

        public void Remove(T element)
        {
            this.set.Remove(element);
        }

        public bool Contains(T element)
        {
            return this.set.ContainsKey(element);
        }

        public void Clear()
        {
            this.set.Clear();
        }

        public void UnionWith(Set<T> other)
        {
            foreach (var el in other)
            {
                if (!this.set.ContainsKey(el))
                {
                    this.set.Add(el, true);
                }
            }
        }

        public void IntersectWith(Set<T> other)
        {
            List<KeyValuePair<T, bool>> toRemove = new List<KeyValuePair<T, bool>>();
            foreach (var pair in this.set)
            {
                if (!other.Contains(pair.Key))
                {
                    toRemove.Add(pair);
                }
            }

            foreach (var pair in toRemove)
            {
                this.set.Remove(pair.Key);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.set)
            {
                yield return element.Key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
