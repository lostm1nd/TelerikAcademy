namespace FindMajorantNumber
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int[] majorantIsTwo = new int[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2 };

            FindMajorant(majorantIsTwo);

            int[] majorantIsOne = new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };

            FindMajorant(majorantIsOne);

            int[] noMajorant = new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 };

            FindMajorant(noMajorant);

            int[] majorantIsThree = new int[] { 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4 };

            FindMajorant(majorantIsThree);
        }

        private static void FindMajorant(int[] numbers)
        {
            int[] clone = numbers.Clone() as int[];

            Array.Sort(clone);

            int frequency = 1;
            int currentNumber = clone[0];
            int majorant = currentNumber;

            for (int i = 1; i < clone.Length; i++)
            {
                if (frequency > clone.Length / 2)
                {
                    break;
                }

                if (currentNumber == clone[i])
                {
                    frequency++;
                }
                else if (currentNumber != clone[i] && i < clone.Length / 2)
                {
                    currentNumber = clone[i];
                    majorant = currentNumber;
                    frequency = 1;
                }
                else
                {
                    break;
                }
            }

            if (frequency > clone.Length / 2)
            {
                Console.WriteLine("The majorant is: {0}", majorant);
            }
            else
            {
                Console.WriteLine("No majorant exists in the array.");
            }
        }
    }
}
