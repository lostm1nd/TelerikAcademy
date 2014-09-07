namespace Bookstore.App.Contracts
{
    public interface ILogger
    {
        void Log(string text);

        void LogLine(string text);

        void LogHeader(string text);

        void LogFooter(string text);
    }
}
