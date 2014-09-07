namespace Bookstore.App
{
    using System;

    using Bookstore.App.Contracts;

    public class ConsoleLogger : ILogger
    {
        public void Log(string text)
        {
            Console.Write(text);
        }

        public void LogLine(string text)
        {
            Console.WriteLine(text);
        }

        public void LogHeader(string text)
        {
            Console.WriteLine(new String('*', 50));
            Console.WriteLine(text);
            Console.WriteLine(new String('*', 50));
        }


        public void LogFooter(string text)
        {
            Console.WriteLine(new String('=', 50));
            Console.WriteLine(text);
            Console.WriteLine(new String('=', 50));
        }
    }
}
