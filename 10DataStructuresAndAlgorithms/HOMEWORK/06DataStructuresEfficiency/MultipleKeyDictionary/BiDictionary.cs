namespace MultipleKeyDictionary
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, V>
    {
        private readonly MultiDictionary<K1, V> hasByFirstKey;
        private readonly MultiDictionary<K2, V> hashBySecondKey;
        private readonly MultiDictionary<Pair<K1, K2>, V> hashByBothKeys;

        public BiDictionary()
        {
            this.hasByFirstKey = new MultiDictionary<K1, V>(true);
            this.hashBySecondKey = new MultiDictionary<K2, V>(true);
            this.hashByBothKeys = new MultiDictionary<Pair<K1, K2>, V>(true);
        }

        public void Add(K1 firstKey, K2 secondKey, V value)
        {
            Pair<K1, K2> bothKeys = new Pair<K1, K2>(firstKey, secondKey);

            this.hasByFirstKey.Add(firstKey, value);
            this.hashBySecondKey.Add(secondKey, value);
            this.hashByBothKeys.Add(bothKeys, value);
        }

        public ICollection<V> FindByFirstKey(K1 firstKey)
        {
            return this.hasByFirstKey[firstKey];
        }

        public ICollection<V> FindBySecondKey(K2 secondKey)
        {
            return this.hashBySecondKey[secondKey];
        }

        public ICollection<V> Find(K1 firstKey, K2 secondKey)
        {
            Pair<K1, K2> bothKeys = new Pair<K1, K2>(firstKey, secondKey);
            return this.hashByBothKeys[bothKeys];
        }
    }
}