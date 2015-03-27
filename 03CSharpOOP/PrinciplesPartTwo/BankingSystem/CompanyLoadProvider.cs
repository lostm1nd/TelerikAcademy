namespace BankingSystem
{
    public class CompanyLoadProvider : IInterestProvider
    {
        private const int GrantPeriodInMonths = 2;

        public decimal CalculateInterest(decimal interestRate, int months)
        {
            months -= CompanyLoadProvider.GrantPeriodInMonths;
            if (months < 0)
            {
                months = 0;
            }

            return interestRate * months;
        }
    }
}
