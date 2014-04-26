namespace GenericClassLib
{
    public class GenericList<T> where T : System.IComparable<T>
    {
        //Fiels
        private const int InitialArraySize = 16;
        private T[] elements;
        private int index;

        //Constructors
        public GenericList() : this(InitialArraySize)
        { 
        }

        public GenericList(int capacity)
        {
            if (capacity < 4)
            {
                throw new System.ArgumentException("The initial capacity must be more than 4");
            }

            this.elements = new T[capacity];
            this.index = 0;
        }

        //Properties
        public int Capacity
        {
            get
            { return this.elements.Length; }
        }

        public int Count
        {
            get { return this.index; }
        }

        //Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.elements.Length)
                {
                    throw new System.IndexOutOfRangeException();
                }

                if (index >= this.index)
                {
                    return default(T);
                }

                return this.elements[index];
            }
        }

        //Methods
        public void Add(T element)
        {
            if (this.index == this.elements.Length)
            {
                this.DoubleTheSize();
            }

            this.elements[index] = element;
            this.index++;
        }

        public void Remove()
        {
            this.index--;
        }

        public void Clear()
        {
            this.index = 0;
        }

        public int IndexOf(T element)
        {
            int index = -1;

            for (int i = 0; i < this.index; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.elements.Length)
            {
                throw new System.IndexOutOfRangeException();
            }

            T[] buffer = new T[this.elements.Length];

            for (int i = 0; i < index; i++)
            {
                buffer[i] = this.elements[i];
            }

            for (int i = index + 1; i < this.index; i++)
            {
                buffer[i - 1] = this.elements[i];
            }

            this.elements = buffer;
            this.index--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= this.elements.Length)
            {
                throw new System.IndexOutOfRangeException();
            }

            if (this.index == this.elements.Length)
            {
                this.DoubleTheSize();
            }

            T[] buffer = new T[this.elements.Length];

            for (int i = 0; i < index; i++)
            {
                buffer[i] = this.elements[i];
            }

            buffer[index] = element;

            for (int i = index; i < this.index; i++)
            {
                buffer[i + 1] = this.elements[i];
            }

            this.elements = buffer;
            this.index++;
        }

        public T Min()
        {
            T element = this.elements[0];

            for (int i = 1; i < this.index; i++)
            {
                if (element.CompareTo(this.elements[i]) > 0)
                {
                    element = this.elements[i];
                }
            }

            return element;
        }

        public T Max()
        {
            T element = this.elements[0];

            for (int i = 1; i < this.index; i++)
            {
                if (element.CompareTo(this.elements[i]) < 0)
                {
                    element = this.elements[i];
                }
            }

            return element;
        }

        private void DoubleTheSize()
        {
            T[] doubleBuffer = new T[this.elements.Length * 2];

            for (int i = 0; i < this.index; i++)
            {
                doubleBuffer[i] = this.elements[i];
            }

            this.elements = doubleBuffer;
        }

        //Override ToString
        public override string ToString()
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();

            for (int i = 0; i < this.index; i++)
            {
                result.Append(this.elements[i]);
                if (i < this.index - 1)
                {
                    result.Append(", ");
                }                
            }

            return result.ToString();
        }
    }
}
