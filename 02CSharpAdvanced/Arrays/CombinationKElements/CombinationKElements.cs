
//Write a program that reads two numbers N and K and
//generates all the combinations of K distinct elements from the set [1..N]. 
//N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
using System;

class CombinationKElements
{
    static int sizeN;
    static int elementsK;
    static int[] array;
    static int currentLoop;

    static void Main()
    {
        //get input data
        Console.WriteLine("This program generates all combinations of K elements of the values 1 to N");
        Console.WriteLine("Enter N:");
        sizeN = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter K:");
        elementsK = int.Parse(Console.ReadLine());

        //set the size of the array
        array = new int[elementsK];
        CombinateNchooseK(0, 1);
    }

    //recursive method to get all variations; intro to c# page 362
    static void CombinateNchooseK(int currentLoop, int next)
    {
        if (currentLoop == elementsK)
        {
            PrintLoop();
            return;
        }

        for (int i = next; i <= sizeN; i++)
        {
            array[currentLoop] = i;
            CombinateNchooseK(currentLoop + 1, i + 1);
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