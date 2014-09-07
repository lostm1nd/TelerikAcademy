namespace ToyStore.DataGenerator
{
    using System;

    using ToyStore.DataGenerator.Contracts;

    internal class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.Write(text);
        }

        public void LogLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}