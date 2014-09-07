namespace ToyStore.DataGenerator
{
    using System;

    using ToyStore.DataGenerator.Contracts;

    internal class RandomGenerator : IRandomGenerator
    {
        private static RandomGenerator instance;

        private readonly string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomGenerator();
                }

                return instance;
            }
        }

        public int GenerateInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public double GenerateDouble(int min, int max)
        {
            double result = (max - min) * this.random.NextDouble() + min;
            return Math.Round(result, 2);
        }

        public string GenerateString(int length)
        {
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = this.letters[this.random.Next(0, this.letters.Length)];
            }

            return new String(result);
        }

        public string GenerateString(int length, char[] allowedCharacters)
        {
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = allowedCharacters[this.random.Next(0, allowedCharacters.Length)];
            }

            return new String(result);
        }

        public string GenerateStringWithRandomLenght(int min, int max)
        {
            return this.GenerateString(this.GenerateInt(min, max));
        }

        public string GenerateStringWithRandomLenght(int min, int max, char[] allowedCharacters)
        {
            return this.GenerateString(this.GenerateInt(min, max), allowedCharacters);
        }
    }
}