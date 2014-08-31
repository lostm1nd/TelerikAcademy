namespace SuperSum
{
    using System;
    using System.Linq;

    class Program
    {
        // SuperSum(0, N) = N
        // SuperSum(K, N) = SuperSum(K-1, 1), SuperSum(K-1, 2) ... SuperSum(K-1, N),
        static void Main()
        {
            string[] parameters = Console.ReadLine().Split(' ');
            int k = int.Parse(parameters[0]);
            int n = int.Parse(parameters[1]);

            int[,] table = new int[k + 1, n + 1];

            // when k == 0 we just return N
            for (int i = 0; i < table.GetLength(1); i++)
            {
                table[0, i] = i;
            }

            // each cell in the table is formed from the sum
            // of the cells in the previous row with column index
            // smaller or equal to the current cell column index
            for (int i = 1; i < table.GetLength(0); i++)
            {
                for (int j = 1; j < table.GetLength(1); j++)
                {
                    for (int x = 1; x <= j; x++)
                    {
                        table[i, j] = table[i, j] + table[i - 1, x];
                    }
                }
            }

            // last cell in the table is the sum
            // we are looking for
            Console.WriteLine(table[k, n]);
        }
    }
}