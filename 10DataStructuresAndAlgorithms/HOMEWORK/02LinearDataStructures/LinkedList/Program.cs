namespace LinkedList
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            MyLinkedList<int> numbers = new MyLinkedList<int>();
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(2);
            numbers.Add(10);
            numbers.Add(222);

            Console.WriteLine(numbers.IndexOf(3));
            Console.WriteLine(numbers.IndexOf(2));
            Console.WriteLine(numbers.IndexOf(222));

            Console.WriteLine(numbers.Count);

            Console.WriteLine(numbers.Contains(2));

            Console.WriteLine(numbers.RemoveAt(0).Value);

            Console.WriteLine(numbers.Remove(222).Value);

            Console.WriteLine(numbers.Count);
            
            Console.WriteLine();
        }
    }
}
