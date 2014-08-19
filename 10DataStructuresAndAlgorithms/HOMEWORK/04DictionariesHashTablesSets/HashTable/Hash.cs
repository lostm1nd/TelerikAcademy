namespace HashTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hash<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        private const int InitialCapacity = 16;
        private const float LoadFactor = 0.75F;

        private LinkedList<KeyValuePair<K, V>>[] hashTable;
        private int currentCapacity;
        private int treshold;
        private int size;

        public Hash() : this(Hash<K, V>.InitialCapacity)
        {
        }

        public Hash(int capacity)
        {
            this.hashTable = new LinkedList<KeyValuePair<K, V>>[capacity];
            this.currentCapacity = capacity;
            this.treshold = (int)(capacity * Hash<K, V>.LoadFactor);
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.CountKeyValuePairs();
            }
        }

        public K[] Keys
        {
            get
            {
                return this.GetAllKeys();
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.AddOrChangeValueIfKeyExist(key, value);
            }
        }

        public void Add(K key, V value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            var list = this.GetListByKey(key);
            foreach (var pair in list)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Key is already defined.");
                }
            }

            list.AddLast(new KeyValuePair<K,V>(key, value));
            this.IncreaseSize();
        }

        public void Remove(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            var list = this.GetListByKey(key);

            list.Remove(list.Single(x => x.Key.Equals(key)));
        }

        public V Find(K key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            var list = this.GetListByKey(key);
            foreach (var pair in list)
            {
                if (key.Equals(pair.Key))
                {
                    return pair.Value;
                }
            }

            throw new ArgumentException("Key is not defined");
        }

        public bool ContainsKey(K key)
        {
            try
            {
                Find(key);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        public void Clear()
        {
            this.hashTable = new LinkedList<KeyValuePair<K, V>>[this.currentCapacity];
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.hashTable)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private LinkedList<KeyValuePair<K, V>> GetListByKey(K key)
        {
            int index = Math.Abs(key.GetHashCode() % this.hashTable.Length);

            if (this.hashTable[index] == null)
            {
                this.hashTable[index] = new LinkedList<KeyValuePair<K, V>>();
            }

            return this.hashTable[index];
        }

        private void AddOrChangeValueIfKeyExist(K key, V value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }

            var list = this.GetListByKey(key);

            bool isKeyDefined = false;

            foreach (var pair in list)
            {
                if (pair.Key.Equals(key))
                {
                    isKeyDefined = true;
                    list.Find(pair).Value = new KeyValuePair<K, V>(key, value);
                    break;
                }
            }

            if (!isKeyDefined)
            {
                list.AddLast(new KeyValuePair<K, V>(key, value));
                this.IncreaseSize();
            }
        }

        private void IncreaseSize()
        {
            this.size += 1;
            if (this.size >= this.treshold)
            {
                this.Expand();
            }
        }

        private void Expand()
        {
            this.currentCapacity = this.currentCapacity * 2;
            this.treshold = (int)(this.currentCapacity * Hash<K, V>.LoadFactor);
            this.size = 0;
            LinkedList<KeyValuePair<K, V>>[] oldTable = this.hashTable;
            this.hashTable = new LinkedList<KeyValuePair<K, V>>[this.currentCapacity];

            foreach (var list in oldTable)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        this.Add(pair.Key, pair.Value);
                    }
                }
            }
        }

        private int CountKeyValuePairs()
        {
            int count = 0;
            foreach (var list in this.hashTable)
            {
                if (list != null)
                {
                    count += list.Count;
                }
            }

            return count;
        }

        private K[] GetAllKeys()
        {
            List<K> keys = new List<K>();
            foreach (var list in this.hashTable)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        keys.Add(pair.Key);
                    }
                }
            }

            return keys.ToArray();
        }
    }
}