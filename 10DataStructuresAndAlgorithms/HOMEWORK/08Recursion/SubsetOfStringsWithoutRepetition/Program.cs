namespace SubsetOfStringsWithoutRepetition
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] elements = { "are", "you", "ready", "to", "rumble" };

            GenerateSubset(2, elements);
        }

        private static void GenerateSubset(int subsetSize, string[] elements)
        {
            string[] subset = new string[subsetSize];

            GetSubset(0, subset, 0, elements);
        }

        private static void GetSubset(int index, string[] subset, int startAt, string[] elements)
        {
            if (index == subset.Length)
            {
                Console.WriteLine(string.Join(";", subset));
                return;
            }

            if (startAt == elements.Length)
            {
                return;
            }

            for (int i = startAt; i < elements.Length; i++)
            {
                subset[index] = elements[i];
                GetSubset(index + 1, subset, i + 1, elements);
            }
        }
    }
}
