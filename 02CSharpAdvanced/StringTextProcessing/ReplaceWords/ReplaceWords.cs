//We are given a string containing a list of forbidden
//words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.

using System;
using System.Text;

class Program
{
    static string ReplaceWords(string text, string[] words)
    {
        StringBuilder replaced = new StringBuilder(text);

        for (int i = 0; i < words.Length; i++)
        {
            replaced.Replace(words[i], new string('*', words[i].Length));
        }

        return replaced.ToString();
    }

    static void Main()
    {
        string sampleText = "One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin."
        + "He lay on his armour-like back, and if he lifted his head a little he could see his brown belly, slightly " +
        "domed and divided by arches into stiff sections.";
        Console.WriteLine("---ORIGINAL TEXT----");
        Console.WriteLine(sampleText);

        Console.WriteLine("Choose how many words you want to replace");
        int count = int.Parse(Console.ReadLine());
        string[] forbiddenWords = new string[count];
        Console.WriteLine("Enter words");
        for (int i = 0; i < count; i++)
        {
            forbiddenWords[i] = Console.ReadLine();
        }

        string replacedWords = ReplaceWords(sampleText, forbiddenWords);
        Console.WriteLine("----AFTER REPLACEMENT----");
        Console.WriteLine(replacedWords);
    }
}
