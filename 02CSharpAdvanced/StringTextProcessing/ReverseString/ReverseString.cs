//Write a program that reads a string,
//reverses it and prints the result at the console.


using System;
using System.Text;

class ReverseString
{
    static string ReverseText(string text)
    {
        StringBuilder reversed = new StringBuilder();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversed.Append(text[i]);
        }

        return reversed.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text you want to reverse:");
        string text = Console.ReadLine();

        string reversedText = ReverseText(text);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The reversed text is:");
        Console.WriteLine(reversedText);
        Console.ResetColor();
    }
}
