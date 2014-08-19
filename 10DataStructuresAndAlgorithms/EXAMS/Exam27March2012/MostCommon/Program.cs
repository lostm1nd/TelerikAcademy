namespace MostCommon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void PrintMostFrequentElement(Dictionary<string, int> dict)
        {
            string result = string.Empty;
            int maxCount = 0;
            foreach (var item in dict)
            {
                if (item.Value > maxCount)
                {
                    maxCount = item.Value;
                    result = item.Key;
                }
                else if (item.Value == maxCount)
                {
                    result = result.CompareTo(item.Key) == -1 ? result : item.Key;
                }
            }

            Console.WriteLine(result);
        }

        static void Main()
        {
            Dictionary<string, int> fNames = new Dictionary<string, int>();
            Dictionary<string, int> lNames = new Dictionary<string, int>();
            Dictionary<string, int> year = new Dictionary<string, int>();
            Dictionary<string, int> eyeColor = new Dictionary<string, int>();
            Dictionary<string, int> hairColor = new Dictionary<string, int>();
            Dictionary<string, int> height = new Dictionary<string, int>();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (fNames.ContainsKey(tokens[0])) fNames[tokens[0]]++;
                else fNames[tokens[0]] = 1;

                if (lNames.ContainsKey(tokens[1])) lNames[tokens[1]]++;
                else lNames[tokens[1]] = 1;

                if (year.ContainsKey(tokens[2])) year[tokens[2]]++;
                else year[tokens[2]] = 1;

                if (eyeColor.ContainsKey(tokens[3])) eyeColor[tokens[3]]++;
                else eyeColor[tokens[3]] = 1;

                if (hairColor.ContainsKey(tokens[4])) hairColor[tokens[4]]++;
                else hairColor[tokens[4]] = 1;

                if (height.ContainsKey(tokens[5])) height[tokens[5]]++;
                else height[tokens[5]] = 1;
            }

            PrintMostFrequentElement(fNames);
            PrintMostFrequentElement(lNames);
            PrintMostFrequentElement(year);
            PrintMostFrequentElement(eyeColor);
            PrintMostFrequentElement(hairColor);
            PrintMostFrequentElement(height);
        }
    }
}