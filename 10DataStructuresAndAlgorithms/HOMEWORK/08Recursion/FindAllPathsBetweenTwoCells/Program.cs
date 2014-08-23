namespace FindAllPathsBetweenTwoCells
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static char[,] labyrinth = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'E'},

        };

        static bool[,] visited = new bool[labyrinth.GetLength(0), labyrinth.GetLength(1)];
        static List<string> paths = new List<string>();

        static void Main()
        {
            TraverseLabyrinth(2, 0);
        }

        private static void TraverseLabyrinth(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) ||
                col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (visited[row, col] || labyrinth[row, col] == '*')
            {
                return;
            }

            visited[row, col] = true;
            paths.Add(row + "-" + col);

            if (labyrinth[row, col] == 'E')
            {
                Console.WriteLine(string.Join("; ", paths));
            }
            
            TraverseLabyrinth(row, col - 1);
            TraverseLabyrinth(row, col + 1);
            TraverseLabyrinth(row - 1, col);
            TraverseLabyrinth(row + 1, col);

            visited[row, col] = false;
            paths.RemoveAt(paths.Count - 1);
        }
    }
}