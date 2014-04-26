using System;

class Program
{
    static void Main()
    {
        //create array and store the input in it
        byte[] numbers = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }

        //variables to hold the bit count and the mask that will count the bits
        byte rightBits = 0;
        byte leftBits = 0;
        byte mask = 1;
        byte maskHolder = 0;
        byte searchedPillar = 0;
        byte searchedBits = 0;
        bool foundPillar = false;

        //go through each pillar and check bits on the right and left sides
        for (int pillar = 0; pillar < 8; pillar++) //move pillar
        {
            rightBits = 0;
            leftBits = 0;

            for (int right = 0; right < pillar; right++) //bits right of the pillar
            {
                for (int i = 0; i < 8; i++) //go through all the numbers in the array
                {
                    mask = 1;
                    mask = (byte)(mask << right);
                    maskHolder = (byte)(numbers[i] & mask);
                    maskHolder = (byte)(maskHolder >> right);
                    if (maskHolder == 1) rightBits++;
                }
            }

            for (int left = pillar + 1; left < 8; left++) //bits left of the pillar
            {
                for (int i = 0; i < 8; i++)
                {
                    mask = 1;
                    mask = (byte)(mask << left);
                    maskHolder = (byte)(numbers[i] & mask);
                    maskHolder = (byte)(maskHolder >> left);
                    if (maskHolder == 1) leftBits++;
                }
            }

            if (rightBits == leftBits)
            {
                searchedPillar = (byte)pillar;
                searchedBits = rightBits;
                foundPillar = true;
            }
        }

        if (foundPillar)
        {
            Console.WriteLine(searchedPillar);
            Console.WriteLine(searchedBits);
        }
        else Console.WriteLine("No");
    }
}