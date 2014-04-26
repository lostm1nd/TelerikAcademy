namespace BitArrays
{
    using System;

    class Test
    {
        static void Main()
        {
            BitArray64 bitArray = new BitArray64(1, 0, 1, 1, 0 , 1, 1, 1, 0);

            foreach (var bit in bitArray)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();

            BitArray64 bitArraySecond = new BitArray64(1, 0, 1, 1, 0, 1);
            bitArraySecond.Add(1);
            bitArraySecond.Add(1);
            bitArraySecond.Add(0);

            Console.WriteLine("Third and forth element: " + bitArray[2] + " " + bitArray[3]);

            Console.WriteLine("bitArray.Equals(bitArraySecond): " + bitArray.Equals(bitArraySecond));
            Console.WriteLine("bitArraySecond != bitArray: " + (bitArraySecond != bitArray));

            Console.WriteLine("bitArraySecond.GetHashCode(): " + bitArraySecond.GetHashCode());
            Console.WriteLine("bitArray.GetHashCode(): " + bitArray.GetHashCode());
        }
    }
}
