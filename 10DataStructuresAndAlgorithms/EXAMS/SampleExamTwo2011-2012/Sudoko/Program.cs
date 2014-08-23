namespace Sudoko
{
    using System;

    class Program
    {
        static int[,] sudoko = new int[9, 9];

        static void Main()
        {
            for (int i = 0; i < 9; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < 9; j++)
                {
                    if (line[j] != '-')
                    {
                        sudoko[i, j] = line[j] - '0';
                    }
                }
            }

            SolveSudoko(0, 0);
        }

        private static void PrintSudoko()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(sudoko[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static void SolveSudoko(int row, int col)
        {
            if (col > 8)
            {
                row += 1;
                col = 0;
            }

            if (row == 9)
            {
                PrintSudoko();
                return;
            }

            if (sudoko[row, col] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (IsUsedInRow(i, row) || IsUsedInCol(i, col) || IsUsedInSqure(i, row, col))
                    {
                        continue;
                    }

                    sudoko[row, col] = i;
                    SolveSudoko(row, col+1);
                    sudoko[row, col] = 0;
                }
            }
            else
            {
                SolveSudoko(row, col + 1);
            }
        }

        private static bool IsUsedInSqure(int num, int row, int col)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (sudoko[i, j] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsUsedInCol(int num, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoko[i, col] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsUsedInRow(int num, int row)
        {
            for (int i = 0; i < 9; i++)
            {
                if (sudoko[row, i] == num)
                {
                    return true;
                }
            }

            return false;
        }
    }
}