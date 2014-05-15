//Write a program that reads a list of words,
//separated by spaces and prints the list in an alphabetical order.

using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter some words separated by space or comma:");
        string text = Console.ReadLine();

        char[] separators = { ' ', ',', '\t' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        string sorted = string.Join(", ", words);
        Console.WriteLine("Sorted words:");
        Console.WriteLine(sorted);
    }
}