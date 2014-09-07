namespace ToyStore.DataGenerator.Contracts
{
    public interface ILogger
    {
        void Log(string text);

        void LogLine(string text);
    }
}