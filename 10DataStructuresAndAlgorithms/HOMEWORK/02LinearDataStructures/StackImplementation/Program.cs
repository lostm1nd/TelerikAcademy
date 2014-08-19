namespace StackImplementation
{
    using System;

    class Program
    {
        static void Main()
        {
            Stack<string> words = new Stack<string>();

            words.Push("Sail");
            words.Push("Boat");
            words.Push("Bike");

            Console.WriteLine("Count -> " + words.Count);
            Console.WriteLine("Capacity -> " + words.Capacity);

            Console.WriteLine("Peek -> " + words.Peek());
            Console.WriteLine("Count -> " + words.Count);

            Console.WriteLine("Pop -> " + words.Pop());
            Console.WriteLine("Count -> " + words.Count);

            Console.WriteLine("Contains Sail -> " + words.Contains("Sail"));
            Console.WriteLine("Contains Boat -> " + words.Contains("Boat"));
            Console.WriteLine("Contains Bike -> " + words.Contains("Bike"));

            words.Clear();
            Console.WriteLine("Cleared");
            Console.WriteLine(words.Count);
            Console.WriteLine(words.Capacity);


            for (int i = 0; i < 20; i++)
            {
                words.Push("a");
            }

            Console.WriteLine("Pushed 20 items");
            Console.WriteLine(words.Count);
            Console.WriteLine(words.Capacity);

            Console.WriteLine("To array -> " + string.Join(",", words.ToArray()));

            while (words.Count > 0)
            {
                Console.WriteLine(words.Pop());
            }

            Console.WriteLine("Count -> " + words.Count);
            //Console.WriteLine(words.Pop());
            //Console.WriteLine(words.Peek());
        }
    }
}
