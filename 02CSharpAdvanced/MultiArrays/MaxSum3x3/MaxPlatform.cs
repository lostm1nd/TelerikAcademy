
//Write a program that reads a rectangular matrix of
//size N x M and finds in it the square 3 x 3
//that has maximal sum of its elements.

using System;

class MaxPlatform
{
    static void Main()
    {
        //get input data
        Console.WriteLine("Enter how many rows should the matrix have (more than 3):");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter how many colums should the matrix have (more than 3):");
        int colums = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, colums];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("matrix[{0}, {1}] = ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        //in case you dont want to input your own numbers 
        //int[,] matrix = new int[5, 5]
        //{
        //    { 0, 0, 1, 2, 3 },
        //    { 0, 0, 2, 1, 0 },
        //    { 1, 1, 1, 2, 3 },
        //    { 2, 2, 2, 2, 2 },
        //    { 0, 1, 0, 1, 1 }
        //};

        //print populated matrix
        Console.WriteLine("Your matrix is:");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, -5}", matrix[row, col]);
            }
            Console.WriteLine();
        }

        //find the max sum of 3x3 square
        int currentSum = int.MinValue;
        int maxSum = int.MinValue;
        int[,] maxMatrix = new int[3, 3];
        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (row > 0 && row < matrix.GetLength(0) - 1 && col > 0 && col < matrix.GetLength(1) - 1)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col - 1] +
                                 matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col - 1] +
                                 matrix[row - 1, col] + matrix[row - 1, col + 1] + matrix[row - 1, col - 1];
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;

                    maxMatrix[0, 0] = matrix[row - 1, col - 1];
                    maxMatrix[0, 1] = matrix[row - 1, col];
                    maxMatrix[0, 2] = matrix[row - 1, col + 1];
                    maxMatrix[1, 0] = matrix[row, col - 1];
                    maxMatrix[1, 1] = matrix[row, col];
                    maxMatrix[1, 2] = matrix[row, col + 1];                    
                    maxMatrix[2, 0] = matrix[row + 1, col - 1];
                    maxMatrix[2, 1] = matrix[row + 1, col];
                    maxMatrix[2, 2] = matrix[row + 1, col + 1];
                }
            }
        }

        //output result
        Console.WriteLine("The max sum of any 3x3 square in the matrix is: {0}", maxSum);
        Console.WriteLine("The 3x3 square with max sum is:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0, -5}", maxMatrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}