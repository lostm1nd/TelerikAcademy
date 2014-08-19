namespace LinkedQueue
{
    using System;

    class Program
    {
        static void Main()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();

            Console.WriteLine("Add four strings...");
            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");

            Console.Write("\nCheck if the queue finds the added string -> ");
            Console.WriteLine(queue.Contains("Message Four"));

            Console.WriteLine("\nIterate over the queue");
            while (queue.Count > 0)
            {
                string msg = queue.Dequeue();
                Console.WriteLine(msg);
            }

            Console.Write("\nAdd four strings and test the clear method. Count -> ");
            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");
            queue.Clear();
            Console.WriteLine(queue.Count);
        }
    }
}
