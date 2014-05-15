//Write a program that reads a string from
//the console and prints all different letters
//in the string along with information how many times each letter is found. 

using System;
using System.Collections.Generic;
using System.Linq;

class CountLetters
{
    static void Main()
    {
        Console.WriteLine("Counting letter occurrence in text");
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        text = text.ToLower();

        int[] letterCount = new int[26];
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                int index = text[i] - 'a';
                letterCount[index]++;
            }
        }

        for (int i = 0; i < letterCount.Length; i++)
        {
            if (letterCount[i] > 0)
            {
                Console.WriteLine("The letter \"{0}\" appears: {1} time/s", (char)(i + 'a'), letterCount[i]);
            }            
        }
    }
}