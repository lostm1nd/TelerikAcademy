namespace ToyStore.DataGenerator.Contracts
{
    public interface IRandomGenerator
    {
        int GenerateInt(int min, int max);

        double GenerateDouble(int min, int max);

        string GenerateString(int length);

        string GenerateString(int length, char[] allowedCharacters);

        string GenerateStringWithRandomLenght(int min, int max);

        string GenerateStringWithRandomLenght(int min, int max, char[] allowedCharacters);
    }
}