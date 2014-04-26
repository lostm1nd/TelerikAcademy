using System;
using System.Collections.Generic;

class DepthFirstSearch
{
    static void DFS(int[,] array, int startRow, int startCol)
    {
        int currentValue = array[startRow, startCol];
        visited[startRow, startCol] = true;
        count++;
        if (startRow + 1 < array.GetLength(0) && currentValue == array[startRow + 1, startCol] && !visited[startRow + 1, startCol])
        {
            DFS(array, startRow + 1, startCol);
        }
        if (startRow - 1 >= 0 && currentValue == array[startRow - 1, startCol] && !visited[startRow - 1, startCol])
        {
            DFS(array, startRow - 1, startCol);
        }
        if (startCol + 1 < array.GetLength(1) && currentValue == array[startRow, startCol + 1] && !visited[startRow, startCol + 1])
        {
            DFS(array, startRow, startCol + 1);
        }
        if (startCol - 1 >= 0 && currentValue == array[startRow, startCol - 1] && !visited[startRow, startCol - 1])
        {
            DFS(array, startRow, startCol - 1);
        }

        return;
    }

    static int count = 0;
    static bool[,] visited = new bool[5, 6];
    static int[,] matrix =
    {
        {1, 3, 2, 2, 2, 4},
        {3, 3, 3, 2, 2, 4},
        {4, 3, 1, 2, 3, 3},
        {4, 3, 1, 3, 3, 1},
        {4, 3, 3, 3, 1, 1}
    };

    static void Main()
    {        
        Console.WriteLine("This is the current matrix");
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, -3}", matrix[row, col]);
            }
            Console.WriteLine();
        }

        int maxElements = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                DFS(matrix, row, col);

                if (count > maxElements) maxElements = count;
                count = 0;
            }
        }

        Console.WriteLine("The largest area of equal neighbour elements is: " + maxElements);
    }

}