using System;
class MaxPlatformVer2
{
    static int[,] PopulateMatrix(int rowCount, int colCount)
    {
        int[,] matrix = new int[rowCount, colCount];
        char[] separators = { ' ', ',' };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.WriteLine("Enter value for row {0} separated by space", row + 1);
            string rowValues = Console.ReadLine();
            string[] individualNumber = rowValues.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (col < individualNumber.Length)
                    matrix[row, col] = int.Parse(individualNumber[col]);
            }
        }
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, -5}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        //get input data
        Console.WriteLine("Enter how many rows should the matrix have:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter how many colums should the matrix have:");
        int colums = int.Parse(Console.ReadLine());

        //populate matrix
        int[,] matrix = PopulateMatrix(rows, colums);

        //print populated matrix
        Console.WriteLine("Your matrix is:");
        PrintMatrix(matrix);        

        Console.WriteLine("Enter the size of the max platform you want to search for:");
        int platformSize = int.Parse(Console.ReadLine());

        //search for the max platform        
        if (platformSize > matrix.GetLength(0) || platformSize > matrix.GetLength(1))
        {
            Console.WriteLine("The platform does not exist");
        }
        else
        {
            int maximalSum = int.MinValue;
            int[,] maximalMatrix = new int[platformSize, platformSize];
            FindMaxPlatform(matrix, platformSize, out maximalSum, out maximalMatrix);
            
            Console.WriteLine("The max platform of size {0} is:", platformSize);
            PrintMatrix(maximalMatrix);
            Console.WriteLine("The sum of the platform is {0}", maximalSum);
        }
    }

    static void FindMaxPlatform(int[,] matrix, int platform, out int maxSum, out int[,] maxMatrix)
    {
        
        maxSum = int.MinValue;
        maxMatrix = new int[platform, platform];

        for (int row = 0; row <= matrix.GetLength(0) - platform; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - platform; col++)
            {
                int sum = 0;

                for (int platformRow = row; platformRow < row + platform; platformRow++)
                {
                    for (int platformCol = col; platformCol < col + platform; platformCol++)
                    {
                        sum += matrix[platformRow, platformCol];
                    }
                }

                if (sum > maxSum)
                {
                    maxSum = sum;

                    for (int maxRow = 0; maxRow < platform; maxRow++)
                    {
                        for (int maxCol = 0; maxCol < platform; maxCol++)
                        {
                            maxMatrix[maxRow, maxCol] = matrix[row + maxRow, col + maxCol];
                        }
                    }
                }
            }
        }
    }
}