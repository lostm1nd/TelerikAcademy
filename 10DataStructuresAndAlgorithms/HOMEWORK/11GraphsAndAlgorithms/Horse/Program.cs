namespace Horse
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());
            string[,] board = new string[boardSize, boardSize];

            int startRow = -1;
            int startCol = -1;

            for (int i = 0; i < boardSize; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < tokens.Length; j++)
                {
                    board[i, j] = tokens[j];

                    if (tokens[j] == "s")
                    {
                        startRow = i;
                        startCol = j;
                    }
                }
            }

            int minStepsToExit = FindExitWithBFS(board, startRow, startCol);
            Console.WriteLine(minStepsToExit);
        }

        private static int FindExitWithBFS(string[,] board, int startRow, int startCol)
        {
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];

            // the third int will be the wave count
            Queue<Tuple<int, int, int>> horseMoves = new Queue<Tuple<int, int, int>>();

            horseMoves.Enqueue(new Tuple<int, int, int>(startRow, startCol, 0));
            visited[startRow, startCol] = true;
            while (horseMoves.Count > 0)
            {
                var current = horseMoves.Dequeue();
                if (board[current.Item1, current.Item2] == "e")
                {
                    return current.Item3;
                }

                if (IsValidCell(board, visited, current.Item1-2, current.Item2-1))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 - 2, current.Item2 - 1, current.Item3 + 1));
                    visited[current.Item1 - 2, current.Item2 - 1] = true;
                }

                if (IsValidCell(board, visited, current.Item1-2, current.Item2+1))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 - 2, current.Item2 + 1, current.Item3 + 1));
                    visited[current.Item1 - 2, current.Item2 + 1] = true;
                }

                if (IsValidCell(board, visited, current.Item1+2, current.Item2-1))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 + 2, current.Item2 - 1, current.Item3 + 1));
                    visited[current.Item1 + 2, current.Item2 - 1] = true;
                }

                if (IsValidCell(board, visited, current.Item1+2, current.Item2+1))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 + 2, current.Item2 + 1, current.Item3 + 1));
                    visited[current.Item1 + 2, current.Item2 + 1] = true;
                }

                if (IsValidCell(board, visited, current.Item1+1, current.Item2+2))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 + 1, current.Item2 + 2, current.Item3 + 1));
                    visited[current.Item1 + 1, current.Item2 + 2] = true;
                }

                if (IsValidCell(board, visited, current.Item1-1, current.Item2+2))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 - 1, current.Item2 + 2, current.Item3 + 1));
                    visited[current.Item1 - 1, current.Item2 + 2] = true;
                }

                if (IsValidCell(board, visited, current.Item1+1, current.Item2-2))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 + 1, current.Item2 - 2, current.Item3 + 1));
                    visited[current.Item1 + 1, current.Item2 - 2] = true;
                }

                if (IsValidCell(board, visited, current.Item1-1, current.Item2-2))
                {
                    horseMoves.Enqueue(new Tuple<int, int, int>(current.Item1 - 1, current.Item2 - 2, current.Item3 + 1));
                    visited[current.Item1 - 1, current.Item2 - 2] = true;
                }
            }

            return -1;
        }

        private static bool IsValidCell(string[,] board, bool[,] visited, int row, int col)
        {
            bool isValidRow = row >= 0 && row < board.GetLength(0);
            bool isValidCol = col >= 0 && col < board.GetLength(1);

            return isValidRow && isValidCol && board[row, col] != "x" && !visited[row, col];
        }
    }
}