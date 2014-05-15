//Write a program that extracts from a given text all palindromes

using System;
using System.Collections.Generic;
using System.Linq;

class ExtractPalindromes
{
    static void Main()
    {
        Console.WriteLine("Enter text containing palindromes (ABBA, exe, rotor, etc.):");
        string text = Console.ReadLine();

        char[] separators = { ' ', ',', '.', ':', ';' };
        string[] separatedText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < separatedText.Length; i++)
        {
            int currentWordLen = separatedText[i].Length;
            bool isPalindrome = true;
            for (int j = 0; j < currentWordLen / 2; j++)
            {
                //string arrays is a 2d char array so with the second indexer we can access each char
                if (separatedText[i][j] != separatedText[i][currentWordLen - 1 - j])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome)
            {
                Console.WriteLine(separatedText[i]);
            }
        }
    }
}
