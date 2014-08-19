namespace HashedSet
{
    using System;

    class Program
    {
        static void Main()
        {
            Set<string> firstSet = new Set<string>();
            firstSet.Add("SQL");
            firstSet.Add("Java");
            firstSet.Add("C#");
            firstSet.Add("PHP");

            Set<string> secondSet = new Set<string>();
            secondSet.Add("Oracle");
            secondSet.Add("SQL");
            secondSet.Add("MySQL");

            Set<string> union = new Set<string>();
            union.UnionWith(firstSet);
            union.UnionWith(secondSet);

            Console.Write("Union: ");
            foreach (var el in union)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Union count: " + union.Count);

            union.Remove("Java");
            Console.WriteLine("Count after removing Java: " + union.Count);

            Set<string> intersection = new Set<string>();
            intersection.UnionWith(firstSet);
            intersection.IntersectWith(secondSet);

            Console.Write("Intersection: ");
            foreach (var el in intersection)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();

            try
            {
                intersection.Add("SQL");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Trying to add SQL to intersection - " + ex.Message);
            }
        }
    }
}
