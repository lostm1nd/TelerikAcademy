namespace Carry
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int backpackVolume = int.Parse(Console.ReadLine());
            int roomsCount = int.Parse(Console.ReadLine());
            int[] treasures = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int visitedRooms = 0;

            for (int i = 0; i < treasures.Length; i++)
            {
                if (backpackVolume - treasures[i] >= 0)
                {
                    backpackVolume -= treasures[i];
                    visitedRooms += 1;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(visitedRooms);
        }
    }
}