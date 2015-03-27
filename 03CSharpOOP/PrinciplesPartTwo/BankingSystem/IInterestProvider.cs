namespace BankingSystem
{
    public interface IInterestProvider
    {
        decimal CalculateInterest(decimal interestRate, int months);
    }
}
