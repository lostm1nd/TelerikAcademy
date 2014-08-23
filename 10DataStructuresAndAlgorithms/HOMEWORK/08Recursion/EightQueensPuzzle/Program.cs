namespace EightQueensPuzzle
{
    using System;

    class Program
    {
        static int totalSolutions = 0;
        static int[,] attacked = new int[8, 8];

        static void Main()
        {
            SolveQueensPuzzle(0);

            Console.WriteLine(totalSolutions);
        }

        private static void SolveQueensPuzzle(int colIndex)
        {
            if (colIndex == attacked.GetLength(1))
            {
                totalSolutions += 1;
                return;
            }

            for (int row = 0; row < attacked.GetLength(0); row++)
            {
                if (attacked[row, colIndex] == 0)
                {
                    MarkCells(row, colIndex, 1);
                    SolveQueensPuzzle(colIndex + 1);
                    MarkCells(row, colIndex, -1);
                }
            }
        }

        private static void MarkCells(int row, int col, int attackers)
        {
            // mark the row as attacked
            for (int i = col; i < attacked.GetLength(1); i++)
            {
                attacked[row, i] += attackers;
            }

            // mark the diagonal going up
            int upRow = row;
            int upCol = col;
            while (upRow >= 0 && upCol < attacked.GetLength(1))
            {
                attacked[upRow, upCol] += attackers;
                upRow -= 1;
                upCol += 1;
            }

            // mark the diagonal going down
            int downRow = row;
            int downCol = col;
            while (downRow < attacked.GetLength(0) && downCol < attacked.GetLength(1))
            {
                attacked[downRow, downCol] += attackers;
                downRow += 1;
                downCol += 1;
            }
        }
    }
}