namespace PriorityQueueWithBinaryHeap
{
    using System;

    class Program
    {
        static void Main()
        {
            PriorityQueue<Person> peopleInTheBank = new PriorityQueue<Person>();
            peopleInTheBank.Enqueue(new Person("Pesho", 18));
            peopleInTheBank.Enqueue(new Person("Baba Tinka", 62));
            peopleInTheBank.Enqueue(new Person("Georgi", 22));
            peopleInTheBank.Enqueue(new Person("Todor", 17));
            peopleInTheBank.Enqueue(new Person("Baba Buna", 64));
            peopleInTheBank.Enqueue(new Person("Krasi", 42));
            peopleInTheBank.Enqueue(new Person("Baba Milka", 72));

            while (peopleInTheBank.Count > 0)
            {
                Person next = peopleInTheBank.Dequeue();
                Console.WriteLine(next.Name + " -> " + next.Age);
            }
        }
    }
}
