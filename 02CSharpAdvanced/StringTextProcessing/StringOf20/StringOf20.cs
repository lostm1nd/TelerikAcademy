//Write a program that reads from the console a
//string of maximum 20 characters. If the length of
//the string is less than 20, the rest of the characters
//should be filled with '*'. Print the result string into the console.

using System;
using System.Text;

class StringOf20
{
    static void Main()
    {
        Console.WriteLine("Enter some text with 20 or less characters");
        string text = Console.ReadLine();

        int textLength = text.Length;
        if (textLength > 20)
        {
            Console.WriteLine("Your text contains more than 20 characters");
        }
        else
        {
            StringBuilder correctedText = new StringBuilder(text);
            for (int i = textLength; i < 20; i++)
            {
                correctedText.Append('*');
            }
            Console.WriteLine("Your text contains less than 20 characters");
            Console.WriteLine(correctedText.ToString());
        }
    }
}