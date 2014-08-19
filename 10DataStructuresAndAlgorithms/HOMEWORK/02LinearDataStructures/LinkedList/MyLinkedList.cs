namespace LinkedList
{
    using System;

    public class MyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public MyLinkedList()
        {
            this.Head = null;
            this.Tail = null;
            this.Count = 0;
        }

        public Node<T> Head
        {
            get { return this.head; }
            set { this.head = value; }
        }

        public Node<T> Tail
        {
            get { return this.tail; }
            set { this.tail = value; }
        }

        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

            if (this.Head == null && this.Count == 0)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                this.Tail.Next = node;
                this.Tail = node;
            }

            this.Count++;
        }

        public Node<T> Remove(T value)
        {
            Node<T> previousNode = null;
            Node<T> currentNode = this.Head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    break;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            this.RemoveNode(currentNode, previousNode);

            return currentNode;
        }

        public Node<T> RemoveAt(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException(string.Format("Indexes are in range [{0}, {1})", 0, this.Count));
            }

            int currentIndex = 0;
            Node<T> previousNode = null;
            Node<T> currentNode = this.Head;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.Next;
                currentIndex++;
            }

            this.RemoveNode(currentNode, previousNode);

            return currentNode;
        }

        public int IndexOf(T value)
        {
            int currentIndex = 0;
            Node<T> currentNode = this.Head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentIndex;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return -1;
        }

        public bool Contains(T value)
        {
            int index = this.IndexOf(value);
            bool isFound = index != -1;

            return isFound;
        }

        private void RemoveNode(Node<T> nodeToRemove, Node<T> previous)
        {
            if (nodeToRemove != null)
            {
                this.Count--;
                if (this.Count == 0)
                {
                    this.Head = null;
                    this.Tail = null;
                }
                else if (previous == null)
                {
                    this.Head = nodeToRemove.Next;
                }
                else if (nodeToRemove.Next == null)
                {
                    this.Tail = previous;
                }
                else
                {
                    previous.Next = nodeToRemove.Next;
                }

                // Disconnect the node so that the list
                // cannot be changed from the returned node.
                nodeToRemove.Next = null;
            }
        }
    }
}
