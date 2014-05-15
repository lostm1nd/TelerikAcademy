//Write a program that finds how many times a
//substring is contained in a given text (perform case insensitive search).

using System;
using System.Text;

class CountSubstring
{
    static int CountSubstringMethod(string text, string substring)
    {
        int count = 0;
        int startIndex = 0;
        int index = text.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase);

        if (index == -1)
        {
            return count;
        }
        else
        {
            while (index != -1)
            {
                PrintMatchingSubstring(startIndex, index, text, substring);
                count++;
                startIndex = index + substring.Length;
                index = text.IndexOf(substring, index + 1, StringComparison.InvariantCultureIgnoreCase);
            }
            if (startIndex < text.Length)
            {
                Console.Write(text.Substring(startIndex));
            }
            Console.WriteLine();
            return count;
        }
    }

    static void PrintMatchingSubstring(int startIndex, int endIndex, string text, string substring)
    {
        Console.Write(text.Substring(startIndex, endIndex - startIndex));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(text.Substring(endIndex, substring.Length));
        Console.ResetColor();
    }

    static void Main()
    {
        string originalText = "We are living in an yellow submarine.\nWe don't have anything else. " +
            "Inside the submarine is very tight.\nSo we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine("------TEXT------");
        Console.WriteLine(originalText);

        Console.WriteLine("----Input the substring which you want to count----");
        string substring = Console.ReadLine();

        int count = CountSubstringMethod(originalText, substring);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The substring \"{0}\" appears {1} time/s in the text.", substring, count);
        Console.ResetColor();
    }
}