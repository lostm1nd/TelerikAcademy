namespace ExtractStringsOcurringOddTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string text = "Lorem Proin ipsum rutrum dolor sit amet, consectetur rutrum adipiscing elit." +
                "Morbi sagittis elit lorem ut nisl tempus, amet Lorem a rutrum purus ornare. Proin viverra.";

            string[] words = text.ToLower().Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (wordFrequency.ContainsKey(words[i]))
                {
                    wordFrequency[words[i]]++;
                }
                else
                {
                    wordFrequency[words[i]] = 1;
                }
            }

            foreach (var pair in wordFrequency)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
                }
            }
        }
    }
}
