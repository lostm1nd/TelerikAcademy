//Write a program that converts a string
//to a sequence of C# Unicode character literals.

using System;
using System.Collections.Generic;
using System.Linq;

class TextToUnicode
{
    static void Main()
    {
        Console.WriteLine("Enter a word to see its Unicode representation:");
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            int code = (int)text[i];
            Console.Write("\\u{0:x4} ", code);
        }
    }
}
