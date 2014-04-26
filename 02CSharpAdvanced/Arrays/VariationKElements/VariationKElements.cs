
//Write a program that reads two numbers N and K and
//generates all the variations of K elements from the set [1..N].
using System;

class VariationKElements
{
    static int sizeN;
    static int elementsK;
    static int[] array;
    static int currentLoop;

    static void Main()
    {
        //get input data
        Console.WriteLine("This program generates all variations of K elements of the values 1 to N");
        Console.WriteLine("Enter N:");
        sizeN = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter K:");
        elementsK = int.Parse(Console.ReadLine());

        //set the size of the array
        array = new int[elementsK];
        VariateNchooseK(0);
    }

    //recursive method to get all variations; intro to c# page 362
    static void VariateNchooseK(int currentLoop)
    {
        if (currentLoop == elementsK)
        {
            PrintLoop();
            return;
        }

        for (int i = 1; i <= sizeN; i++)
        {
            array[currentLoop] = i;
            VariateNchooseK(currentLoop + 1);
        }
    }

    //method to print the number from the generated array
    static void PrintLoop()
    {
        for (int i = 0; i < elementsK; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }
}