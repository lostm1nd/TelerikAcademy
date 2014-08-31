namespace Tribonnaci
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int count = int.Parse(input[3]);

            LinkedList<decimal> tribonnaci = new LinkedList<decimal>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                tribonnaci.AddLast(decimal.Parse(input[i]));
            }

            if (count <= tribonnaci.Count)
            {
                var node = tribonnaci.First;
                for (int i = 1; i < count; i++)
                {
                    node = node.Next;
                }

                Console.WriteLine(node.Value);
            }
            else
            {
                for (int i = tribonnaci.Count; i < count; i++)
                {
                    decimal next = tribonnaci.First.Value + tribonnaci.First.Next.Value + tribonnaci.First.Next.Next.Value;
                    tribonnaci.RemoveFirst();
                    tribonnaci.AddLast(next);
                }

                Console.WriteLine(tribonnaci.Last.Value);
            }
        }
    }
}