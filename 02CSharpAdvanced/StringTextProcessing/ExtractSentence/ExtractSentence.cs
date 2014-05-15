//Write a program that extracts from a
//given text all sentences containing given word.

using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentence
{
    static void FindMatch(string text, string word)
    {
        string pattern = "\\b" + word + "\\b";
        Match match = Regex.Match(text, pattern);

        if (match.Success)
        {
            int index = match.Index;
            Console.WriteLine("The word appears in the following sentece/s:");
            while (match.Success)
            {
                GetSentence(text, index);
                match = match.NextMatch();
                index = match.Index;
            }
        }
        else
        {
            Console.WriteLine("There are no matches for the word: {0}", word);
        }
    }

    static void GetSentence(string text, int wordIndex)
    {
        int sentenceEnd = text.IndexOf(".", wordIndex);
        if (sentenceEnd == -1)
        {
            sentenceEnd = text.Length - 1;
        }

        int sentenceStart = -1;
        for (int i = wordIndex; i >= 0; i--)
        {
            if (text[i] == '.')
            {
                sentenceStart = i + 1;
                break;
            }
        }
        if (sentenceStart == -1)
        {
            sentenceStart = 0;
        }

        string sentence = text.Substring(sentenceStart, sentenceEnd - sentenceStart + 1);
        Console.WriteLine(sentence);
    }

    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else.\n" +
            "Inside the submarine is very tight. So we are drinking all the day.\nWe will move out of it in 5 days.";

        Console.WriteLine("----TEXT----");
        Console.WriteLine(text);

        Console.WriteLine("Choose a word from the text:");
        string userWord = Console.ReadLine();
        FindMatch(text, userWord);
        
    }
}