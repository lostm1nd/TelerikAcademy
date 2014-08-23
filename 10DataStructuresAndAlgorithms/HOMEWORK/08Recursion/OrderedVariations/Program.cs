namespace OrderedVariations
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] elements = { "a", "b", "c", "d", "e" };

            GenerateOrderedVariation(2, elements);
        }

        private static void GenerateOrderedVariation(int size, string[] elements)
        {
            string[] variation = new string[size];

            GetVariations(0, variation, elements);
        }

        private static void GetVariations(int index, string[] variation, string[] elements)
        {
            if (index == variation.Length)
            {
                Console.WriteLine(string.Join("-", variation));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variation[index] = elements[i];
                GetVariations(index + 1, variation, elements);
            }
        }
    }
}
