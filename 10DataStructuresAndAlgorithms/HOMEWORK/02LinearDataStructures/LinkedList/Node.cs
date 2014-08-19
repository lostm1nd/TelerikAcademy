namespace LinkedList
{
    using System;

    public class Node<T>
    {
        private T value;
        private Node<T> next;

        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; } 
        }

        public Node<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
