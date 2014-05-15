//Write a program that reads a number and prints
//it as a decimal number, hexadecimal number, percentage
//and in scientific notation.

using System;
using System.Collections.Generic;
using System.Linq;

class FormatNumber
{
    static void Main()
    {
        Console.WriteLine("Enter a integer number:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("{0, -15}{1:F4}", "Decimal:", number);
        Console.WriteLine("{0, -15}{1:X}", "Hexadecimal:", number);
        Console.WriteLine("{0, -15}{1:P}", "Percet:", number);
        Console.WriteLine("{0, -15}{1:E}", "Scientific:", number);
    }
}