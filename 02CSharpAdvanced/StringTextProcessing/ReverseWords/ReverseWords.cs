using System;
using System.Collections.Generic;
using System.Text;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("Enter some text:");
        string text = Console.ReadLine();
        //string text = "C# is not C++, not PHP and not Delphi!";

        char[] separators = { ' ', ',', '.', ';', ':', '!', '?' };

        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        string[] spacesAndSigns = text.Split(words, StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        StringBuilder reversedText = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            reversedText.Append(words[i]);
            reversedText.Append(spacesAndSigns[i]);
        }

        Console.WriteLine("Reversed text:");
        Console.WriteLine(reversedText.ToString());
    }
}
