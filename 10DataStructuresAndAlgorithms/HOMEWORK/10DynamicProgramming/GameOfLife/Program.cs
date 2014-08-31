namespace GameOfLife
{
    using System;
    using System.Linq;

    class Program
    {
        static bool[,,] table;
        static void Main()
        {
            int generation = int.Parse(Console.ReadLine());
            int[] rowNCols = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            table = new bool[generation + 1, rowNCols[0], rowNCols[1]];

            for (int i = 0; i < rowNCols[0]; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == "1")
                    {
                        table[0, i, j] = true;
                    }
                }
            }

            for (int gen = 1; gen <= generation; gen++)
            {
                int livingCellsCount = 0;
                for (int row = 0; row < table.GetLength(1); row++)
                {
                    for (int col = 0; col < table.GetLength(2); col++)
                    {
                        int livingNeighbours = FindLivingNeighboursCount(gen-1, row, col);

                        if (!table[gen-1, row, col] && livingNeighbours == 3)
                        {
                            table[gen, row, col] = true;
                        }
                        else if (table[gen-1, row, col] && livingNeighbours < 2)
                        {
                            table[gen, row, col] = false;
                        }
                        else if (table[gen-1, row, col] && livingNeighbours > 3)
                        {
                            table[gen, row, col] = false;
                        }
                        else
                        {
                            table[gen, row, col] = table[gen - 1, row, col];
                        }

                        if (table[gen, row, col])
                        {
                            livingCellsCount += 1;
                        }
                    }
                }

                if (gen == generation)
                {
                    Console.WriteLine(livingCellsCount);
                }
            }
        }

        private static int FindLivingNeighboursCount(int generation, int row, int col)
        {
            int prevRow = row - 1;
            int nextRow = row + 1;
            int prevCol = col - 1;
            int nextCol = col + 1;
            int count = 0;

            if (prevRow >= 0)
            {
                if (table[generation, prevRow, col])
                {
                    count += 1;
                }

                if (prevCol >= 0 && table[generation, prevRow, prevCol])
                {
                    count += 1;
                }

                if (nextCol < table.GetLength(2) && table[generation, prevRow, nextCol])
                {
                    count += 1;
                }
            }

            if (prevCol >= 0 && table[generation, row, prevCol])
            {
                count += 1;
            }

            if (nextCol < table.GetLength(2) && table[generation, row, nextCol])
            {
                count += 1;
            }

            if (nextRow < table.GetLength(1))
            {
                if (table[generation, nextRow, col])
                {
                    count += 1;
                }

                if (prevCol >= 0 && table[generation, nextRow, prevCol])
                {
                    count += 1;
                }

                if (nextCol < table.GetLength(2) && table[generation, nextRow, nextCol])
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}