namespace InasBoyfriend
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            string[] names = new string[size];
            for (int i = 0; i < size; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                names[i] = input[0];

                for (int j = 0; j < input[1].Length; j++)
                {
                    if (input[1][j] == '1')
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            int maxLikes = 0;
            int maxLikesIndex = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int rowSum = 0;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    rowSum += matrix[row, col];
                }

                if (rowSum > maxLikes)
                {
                    maxLikes = rowSum;
                    maxLikesIndex = row;
                }
            }

            Console.WriteLine(names[maxLikesIndex]);
        }
    }
}