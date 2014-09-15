namespace Salaries
{
    using System;

    class Program
    {
        static long[] memoSalary;

        static void Main()
        {
            int employees = int.Parse(Console.ReadLine());

            memoSalary = new long[employees];
            bool[,] matrix = new bool[employees, employees];

            for (int i = 0; i < employees; i++)
            {
                memoSalary[i] = -1;
                string input = Console.ReadLine();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == 'Y')
                    {
                        matrix[i, j] = true;
                    }
                }
            }

            long totalSalary = 0;
            for (int i = 0; i < employees; i++)
            {
                totalSalary += CalculateEmployeeSalary(matrix, i);
            }

            Console.WriteLine(totalSalary);
        }

        private static long CalculateEmployeeSalary(bool[,] matrix, int rowIndex)
        {
            if (memoSalary[rowIndex] != -1)
            {
                return memoSalary[rowIndex];
            }

            long employeeSalary = 0;

            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                if (matrix[rowIndex, colIndex])
                {
                    employeeSalary += CalculateEmployeeSalary(matrix, colIndex);
                }
            }

            return memoSalary[rowIndex] =  employeeSalary != 0 ? employeeSalary : 1;
        }
    }
}