namespace LargestAreaOfEmptyCells
{
    using System;

    class Program
    {
        static int largestAreaOfFreeCells = 0;
        static readonly char[,] matrix =
        {
            { ' ', ' ', ' ', '*', ' ', '*', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', '*', ' ', '*', '*', '*', ' ' },
            { ' ', '*', ' ', ' ', '*', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', '*', ' ', ' ' },
            { ' ', ' ', ' ', ' ', '*', ' ', ' ' }
        };

        static void Main()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    CountEmpyAdjecentCells(i, j, 0);
                }
            }

            Console.WriteLine();
        }

        private static void CountEmpyAdjecentCells(int row, int col, int count)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1) ||
                matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                if (count > largestAreaOfFreeCells)
                {
                    largestAreaOfFreeCells = count;
                }

                return;
            }

            matrix[row, col] = 'v';
            CountEmpyAdjecentCells(row, col - 1, count + 1);
            CountEmpyAdjecentCells(row, col + 1, count + 1);
            CountEmpyAdjecentCells(row - 1, col, count + 1);
            CountEmpyAdjecentCells(row + 1, col, count + 1);
        }
    }
}
