//Write a program that reads a string from the
//console and replaces all series of consecutive identical letters with a single one. 
using System;
using System.Text;

class Program
{
    static string RemoveRepetition(string text)
    {
        StringBuilder removed = new StringBuilder();
        char current = text[0];

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != current)
            {
                removed.Append(current);
                current = text[i];
            }
        }
        removed.Append(current);
        return removed.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Enter some text with repeating characters:");
        string text = Console.ReadLine();

        string removedRepeating = RemoveRepetition(text);
        Console.WriteLine(removedRepeating);
    }
}