using System;

class PermutationKElements
{
    static int sizeN;
    static int[] array;
    static bool[] used;
    static int currentLoop;

    static void Main()
    {
        //get input data
        Console.WriteLine("This program generates all permutations of the values 1 to N");
        Console.WriteLine("Enter N:");
        sizeN = int.Parse(Console.ReadLine());

        array = new int[sizeN];
        used = new bool[sizeN + 1];
        PermuteNchooseK(0, used);
    }

    static void PermuteNchooseK(int currentLoop, bool[] used)
    {
        if (currentLoop == sizeN)
        {
            PrintLoop();
            return;
        }

        for (int i = 1; i <= sizeN; i++)
        {
            if (used[i]) continue;

            used[i] = true;
            array[currentLoop] = i;
            PermuteNchooseK(currentLoop + 1, used);
            used[i] = false;
        }
    }

    //method to print the number from the generated array
    static void PrintLoop()
    {
        for (int i = 0; i < sizeN; i++)
        {
            Console.Write("{0} ", array[i]);
        }
        Console.WriteLine();
    }
}