namespace BitArrays
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class BitArray64 : IEnumerable<int>
    {
        // Fileds
        private int index;
        private ulong bitArray;
        private ulong tempElement;

        // Constructor
        public BitArray64()
        {
            this.index = 0;
            this.bitArray = 0;
        }

        public BitArray64(params int[] elements) : this()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.Add(elements[i]);
            }
        }

        // Methods
        public void Add(int element)
        {
            if (!(element == 0 || element == 1))
            {
                throw new ArgumentException("The values allowed in the array are only 0 or 1");
            }

            this.tempElement = (ulong)element;
            this.tempElement = this.tempElement << index;
            this.bitArray = this.bitArray | this.tempElement;
            index++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.index; i++)
            {
                sb.Append((this.bitArray >> i) & 1);
                if (i < this.index - 1)
                {
                    sb.Append(", ");
                }                
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            return (int)(31 * this.index ^ (int)this.bitArray);
        }

        public override bool Equals(object obj)
        {
            try
            {
                ulong arrayValue = (ulong)typeof(BitArray64).GetField("bitArray", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);

                if (this.bitArray != arrayValue)
                {
                    return false;
                }

                return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        // Indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= this.index)
                {
                    throw new IndexOutOfRangeException("The index is out of the bounds of the array");
                }

                return (int)((this.bitArray >> index) & 1);
            }
        }

        // Operators
        public static bool operator ==(BitArray64 first, BitArray64 second)
        {
            return BitArray64.Equals(first, second);
        }

        public static bool operator !=(BitArray64 first, BitArray64 second)
        {
            return !(BitArray64.Equals(first, second));
        }

        // Implementing IEnumerable<int>
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.index; i++)
            {
                yield return (int)((this.bitArray >> i) & 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
