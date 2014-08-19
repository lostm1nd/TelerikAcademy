namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private class Node<T>
        {
            public T Value;
            public Node<T> Next;

            public Node(T value)
            {
                this.Value = value;
                this.Next = null;
            }
        }

        private int count;
        private Node<T> head;
        private Node<T> tail;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Enqueue(T item)
        {
            var node = new Node<T>(item);

            if (this.head == null)
            {
                this.head = node;
                this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                this.tail = node;
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.head == null || this.count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var node = this.head;
            this.head = this.head.Next;
            this.count--;

            return node.Value;
        }

        public T Peek()
        {
            return this.head.Value;
        }

        public bool Contains(T item)
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            var current = this.head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }
    }
}
