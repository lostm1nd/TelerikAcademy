namespace StackImplementation
{
    using System;

    public class Stack<T>
    {
        private const int InitialCapacity = 8;

        private int index;
        private T[] stack;

        public Stack() : this(Stack<T>.InitialCapacity)
        {
        }

        public Stack(int capacity)
        {
            this.stack = new T[capacity];
            this.index = 0;
        }

        public int Count
        {
            get { return this.index; }
        }

        public int Capacity
        {
            get { return this.stack.Length; }
        }

        public void Push(T item)
        {
            if (this.index >= this.stack.Length)
            {
                this.stack = this.DoubleStackCapacity();
            }

            this.stack[index] = item;
            this.index++;
        }

        public T Pop()
        {
            this.ThrowExceptionIfStackIsEmpty();

            this.index--;
            return this.stack[this.index];
        }

        public T Peek()
        {
            this.ThrowExceptionIfStackIsEmpty();

            return this.stack[this.index - 1];
        }

        public void Clear()
        {
            this.stack = new T[this.stack.Length];
            this.index = 0;
        }

        public bool Contains(T item)
        {
            if (this.index > 0)
            {
                for (int i = 0; i < this.index; i++)
                {
                    if (this.stack[i].Equals(item))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.index];

            for (int i = 0; i < this.index; i++)
            {
                array[i] = this.stack[i];
            }

            return array;
        }

        private T[] DoubleStackCapacity()
        {
            T[] doubled = new T[this.stack.Length * 2];

            for (int i = 0; i < this.stack.Length; i++)
            {
                doubled[i] = this.stack[i];
            }

            return doubled;
        }

        private void ThrowExceptionIfStackIsEmpty()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
        }
    }
}
