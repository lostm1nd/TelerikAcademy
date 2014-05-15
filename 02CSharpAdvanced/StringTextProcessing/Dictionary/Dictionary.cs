using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

class Dictionary
{
    static void Main()
    {
        Dictionary<string, string> words = new Dictionary<string, string>();
        using (StreamReader reader = new StreamReader("../../Words.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                int index = line.IndexOf(" ");
                string word = line.Substring(0, index).ToLower();
                index = line.IndexOf(" ", index + 1);
                string meaning = line.Substring(index + 1).ToLower();

                words.Add(word, meaning);
                line = reader.ReadLine();
            }
        }

        Console.WriteLine("The dictionary contains the following words:");
        foreach (var word in words.Keys)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine("Input a word to see its explanation:");
        string wordToSearch = Console.ReadLine();
        Console.WriteLine("{0} - {1}", wordToSearch, words[wordToSearch]);
    }
}