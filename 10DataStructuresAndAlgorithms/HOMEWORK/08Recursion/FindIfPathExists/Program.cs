namespace FindIfPathExists
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static bool foundExit = false;
        static readonly bool[,] labyrinth = new bool[100, 100];
        static readonly bool[,] visited = new bool[100, 100];

        static void Main()
        {
            labyrinth[75, 90] = true;

            TraverseLabyrinth(15, 10);

            if (foundExit)
            {
                Console.WriteLine("Exit was found.");
            }
            else
            {
                Console.WriteLine("No exit was found.");
            }
        }

        private static void TraverseLabyrinth(int row, int col)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(new Tuple<int, int>(row, col));
            visited[row, col] = true;

            while (queue.Count > 0)
            {
                var rowAndCol = queue.Dequeue();
                var currentRow = rowAndCol.Item1;
                var currentCol = rowAndCol.Item2;

                if (labyrinth[currentRow, currentCol])
                {
                    foundExit = true;
                    break;
                }

                if (IsValidLabyrinthPosition(currentRow, currentCol - 1))
                {
                    queue.Enqueue(new Tuple<int, int>(currentRow, currentCol - 1));
                    visited[currentRow, currentCol - 1] = true;
                }

                if (IsValidLabyrinthPosition(currentRow, currentCol + 1))
                {
                    queue.Enqueue(new Tuple<int, int>(currentRow, currentCol + 1));
                    visited[currentRow, currentCol + 1] = true;
                }

                if (IsValidLabyrinthPosition(currentRow - 1, currentCol))
                {
                    queue.Enqueue(new Tuple<int, int>(currentRow - 1, currentCol));
                    visited[currentRow - 1, currentCol] = true;
                }

                if (IsValidLabyrinthPosition(currentRow + 1, currentCol))
                {
                    queue.Enqueue(new Tuple<int, int>(currentRow + 1, currentCol));
                    visited[currentRow + 1, currentCol] = true;
                }
            }
        }

        private static bool IsValidLabyrinthPosition(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) ||
                col < 0 || col >= labyrinth.GetLength(1) ||
                visited[row, col])
            {
                return false;
            }

            return true;
        }
    }
}