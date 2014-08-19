namespace PriorityQueueWithBinaryHeap
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        private readonly List<T> queue;

        public PriorityQueue()
            : this(PriorityQueue<T>.InitialCapacity)
        {
        }

        public PriorityQueue(int capacity)
        {
            this.queue = new List<T>(capacity);
        }

        public int Count
        {
            get { return this.queue.Count; }
        }

        public void Enqueue(T item)
        {
            this.queue.Add(item);
            this.HeapifyUp();
        }

        public T Dequeue()
        {
            T root = this.queue[0];

            int lastElementIndex = this.queue.Count - 1;
            this.queue[0] = this.queue[lastElementIndex];
            this.queue.RemoveAt(lastElementIndex);

            if (this.queue.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return root;
        }

        private void HeapifyUp()
        {
            int childIndex = this.queue.Count - 1;
            int parentIndex = (childIndex - 1) / 2;
            T newlyAddedItem = this.queue[childIndex];

            while (parentIndex >= 0 && newlyAddedItem.CompareTo(this.queue[parentIndex]) > 0)
            {
                T swap = this.queue[parentIndex];
                this.queue[parentIndex] = newlyAddedItem;
                this.queue[childIndex] = swap;

                parentIndex = (parentIndex - 1) / 2;
                childIndex = (childIndex - 1) / 2;
            }
        }

        private void HeapifyDown(int rootIndex)
        {
            int leftChildIndex = rootIndex * 2 + 1;
            int rightChildIndex = rootIndex * 2 + 2;
            int maxChildIndex = rootIndex;

            if (leftChildIndex < this.queue.Count && this.queue[leftChildIndex].CompareTo(this.queue[maxChildIndex]) > 0)
            {
                maxChildIndex = leftChildIndex;
            }

            if (rightChildIndex < this.queue.Count && this.queue[rightChildIndex].CompareTo(this.queue[maxChildIndex]) > 0)
            {
                maxChildIndex = rightChildIndex;
            }

            if (this.queue[rootIndex].CompareTo(this.queue[maxChildIndex]) < 0)
            {
                T swap = this.queue[rootIndex];
                this.queue[rootIndex] = this.queue[maxChildIndex];
                this.queue[maxChildIndex] = swap;

                this.HeapifyDown(maxChildIndex);
            }
        }
    }
}
