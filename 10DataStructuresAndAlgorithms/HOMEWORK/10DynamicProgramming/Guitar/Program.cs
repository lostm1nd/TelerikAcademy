namespace Guitar
{
    using System;
    using System.Linq;

    class Program
    {

        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] changes = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            int soundLevel = int.Parse(Console.ReadLine());
            int maxSoundLevel = int.Parse(Console.ReadLine());

            bool[,] songSoundLevel = new bool[count+1, maxSoundLevel + 1];
            songSoundLevel[0, soundLevel] = true;

            FindMaxSoundLevel(songSoundLevel, changes);

            int result = -1;
            for (int i = songSoundLevel.GetLength(1) - 1; i >= 0; i--)
            {
                if (songSoundLevel[count, i])
                {
                    result = i;
                    break;
                }
            }

            Console.WriteLine(result);
        }

        private static void FindMaxSoundLevel(bool[,] songSoundLevel, int[] changes)
        {
            for (int i = 0; i < changes.Length; i++)
            {
                for (int j = 0; j < songSoundLevel.GetLength(1); j++)
                {
                    if (songSoundLevel[i, j])
                    {
                        int decreasedSoundLevel = j - changes[i];
                        int increasedSoundLevel = j + changes[i];

                        if (decreasedSoundLevel >= 0)
                        {
                            songSoundLevel[i+1, decreasedSoundLevel] = true;
                        }

                        if (increasedSoundLevel < songSoundLevel.GetLength(1))
                        {
                            songSoundLevel[i+1, increasedSoundLevel] = true;
                        }
                    }
                }
            }
        }
    }
}