namespace Permutations1toN
{
    using System;

    class Program
    {
        static void Main()
        {
            PermutationsForOneTo(3);
        }

        private static void PermutationsForOneTo(int upperBoundry)
        {
            int[] permutations = new int[upperBoundry];
            bool[] used = new bool[upperBoundry + 1];

            GetPermutations(0, permutations, used);
        }

        private static void GetPermutations(int index, int[] permutations, bool[] isUsed)
        {
            if (index == permutations.Length)
            {
                Console.WriteLine("{" + string.Join(",", permutations) + "}");
                return;
            }

            for (int i = 1; i <= permutations.Length; i++)
            {
                if (!isUsed[i])
                {
                    isUsed[i] = true;
                    permutations[index] = i;
                    GetPermutations(index + 1, permutations, isUsed);
                    isUsed[i] = false;
                }
            }
        }
    }
}
