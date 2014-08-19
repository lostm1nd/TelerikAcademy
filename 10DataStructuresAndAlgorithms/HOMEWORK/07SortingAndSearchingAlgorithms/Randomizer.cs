namespace SortingHomework
{
    using System;

    public static class Randomizer
    {
        private static readonly Random randomGenerator = new Random();

        public static int Next(int from, int to)
        {
            return Randomizer.randomGenerator.Next(from, to);
        }
    }
}
