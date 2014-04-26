using System;

class FindSumInSequenceVer2
{
    static void Main(string[] args)
    {
        //read the size of the array and initialize it
        Console.WriteLine("Enter the size of the array:");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numbers in the array (one on line):");
        int[] userArray = new int[size];
        for (int i = 0; i < size; i++)
        {
            userArray[i] = int.Parse(Console.ReadLine());
        }

        //what sum are we searching
        Console.WriteLine("What sum are we searching in the array:");
        int userSum = int.Parse(Console.ReadLine());

        //solution
        for (int i = 0; i < userArray.Length; i++)
        {
            int currentSum = userArray[i];
            int startIndex = i;
            if (currentSum == userSum)
            {
                Console.WriteLine("{0} = {1}", currentSum, userSum);
            }
            else
            {
                for (int k = i+1; k < userArray.Length; k++)
                {
                    currentSum += userArray[k];
                    int endIndex = k;
                    if (currentSum == userSum)
                    {
                        for (int j = startIndex; j <= endIndex; j++)
                        {
                            Console.Write(userArray[j] + " ");
                        }
                        Console.WriteLine("= " + userSum);
                    }
                    else if (currentSum > userSum) break;
                }
            }
        }
    }
}