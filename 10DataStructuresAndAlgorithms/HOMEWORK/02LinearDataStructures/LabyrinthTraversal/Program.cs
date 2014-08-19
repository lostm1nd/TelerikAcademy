namespace LabyrinthTraversal
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int[,] matrix = GetMatrix();

            TraverseMatrix(matrix, 2, 1);

            MarkUnreachableCells(matrix, 2, 1);

            PrintMatrix(matrix);
        }

        private static int[,] GetMatrix()
        {
            int[,] matrix = new int[6, 6];
            matrix[1, 1] = -1;
            matrix[3, 1] = -1;
            matrix[2, 2] = -1;
            matrix[0, 3] = -1;
            matrix[1, 3] = -1;
            matrix[4, 3] = -1;
            matrix[5, 3] = -1;
            matrix[2, 4] = -1;
            matrix[4, 4] = -1;
            matrix[0, 5] = -1;
            matrix[1, 5] = -1;
            matrix[5, 5] = -1;

            return matrix;
        }

        private static void TraverseMatrix(int[,] matrix, int row, int col)
        {
            IsValidPosition(row, matrix, col);

            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            Queue<int[]> queue = new Queue<int[]>();

            matrix[row, col] = 0;
            queue.Enqueue(new int[] { row, col });

            while (queue.Count > 0)
            {
                int[] position = queue.Dequeue();
                visited[position[0], position[1]] = true;

                if (IsUpperCellValid(matrix, position[0], position[1]) && !visited[position[0] - 1, position[1]])
                {
                    matrix[position[0] - 1, position[1]] = matrix[position[0], position[1]] + 1;
                    queue.Enqueue(new int[] { position[0] - 1, position[1] });
                }

                if (IsLowerCellValid(matrix, position[0], position[1]) && !visited[position[0] + 1, position[1]])
                {
                    matrix[position[0] + 1, position[1]] = matrix[position[0], position[1]] + 1;
                    queue.Enqueue(new int[] { position[0] + 1, position[1] });
                }

                if (IsLeftCellValid(matrix, position[0], position[1]) && !visited[position[0], position[1] - 1])
                {
                    matrix[position[0], position[1] - 1] = matrix[position[0], position[1]] + 1;
                    queue.Enqueue(new int[] { position[0], position[1] - 1 });
                }

                if (IsRightCellValid(matrix, position[0], position[1]) && !visited[position[0], position[1] + 1])
                {
                    matrix[position[0], position[1] + 1] = matrix[position[0], position[1]] + 1;
                    queue.Enqueue(new int[] { position[0], position[1] + 1 });
                }
            }
        }
  
        private static bool IsValidPosition(int row, int[,] matrix, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                throw new ArgumentException(string.Format("Invalid row: {0}. Must be in range [0, {1})", row, matrix.GetLength(0)));
            }

            if (col < 0 || col >= matrix.GetLength(1))
            {
                throw new ArgumentException(string.Format("Invalid row: {0}. Must be in range [0, {1})", col, matrix.GetLength(1)));
            }

            if (matrix[row, col] == -1)
            {
                throw new InvalidOperationException("Position is not accessible: " + row + ", " + col);
            }

            return true;
        }

        private static bool IsRightCellValid(int[,] matrix, int row, int col)
        {
            int newCol = col + 1;
            bool isColValid = newCol < matrix.GetLength(1);

            if (isColValid)
            {
                return matrix[row, newCol] != -1;
            }

            return false;
        }

        private static bool IsLeftCellValid(int[,] matrix, int row, int col)
        {
            int newCol = col - 1;
            bool isColValid = newCol >= 0;

            if (isColValid)
            {
                return matrix[row, newCol] != -1;
            }

            return false;
        }

        private static bool IsLowerCellValid(int[,] matrix, int row, int col)
        {
            int newRow = row + 1;
            bool isRowValid = newRow < matrix.GetLength(0);

            if (isRowValid)
            {
                return matrix[newRow, col] != -1;
            }

            return false;
        }

        private static bool IsUpperCellValid(int[,] matrix, int row, int col)
        {
            int newRow = row - 1;
            bool isRowValid = newRow >= 0;
            
            if (isRowValid)
            {
                return matrix[newRow, col] != -1;
            }

            return false;
        }

        private static void MarkUnreachableCells(int[,] matrix, int startRow, int startCol)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != startRow && j != startCol && matrix[i, j] == 0)
                    {
                        matrix[i, j] = -2;
                    }
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == -1)
                    {
                        Console.Write('x'.ToString().PadRight(5));
                    }
                    else if (matrix[i, j] == -2)
                    {
                        Console.Write('u'.ToString().PadRight(5));
                    }
                    else
                    {
                        Console.Write(matrix[i, j].ToString().PadRight(5));
                    }

                }
                Console.WriteLine();
            }
        }
    }
}