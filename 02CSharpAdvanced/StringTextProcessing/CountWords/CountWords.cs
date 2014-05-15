using System;
using System.Collections.Generic;
using System.Linq;

class CountWords
{
    static void Main()
    {
        Console.WriteLine("This program counts the occurrence of each word in a text");
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();

        char[] separators = { ' ', ',', '.', '-', ':', ';' };
        string[] separatedText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        //adding the words into the dictionary with ToLower so we can ignore the casing of the words
        Dictionary<string, int> words = new Dictionary<string, int>();
        for (int i = 0; i < separatedText.Length; i++)
        {
            if (words.ContainsKey(separatedText[i].ToLower()))
            {
                words[separatedText[i].ToLower()]++;
            }
            else
            {
                words.Add(separatedText[i].ToLower(), 1);
            }
        }

        //sorting alphabetically
        List<string> sortedKeys = words.Keys.ToList();
        sortedKeys.Sort();

        //output each word and the times it appears in the text
        foreach (var key in sortedKeys)
        {
            Console.WriteLine("The word \"{0}\" appears: {1} time/s", key, words[key]);
        }

    }
}