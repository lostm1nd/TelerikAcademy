namespace BankingSystem
{
    public class IndividualMortgageProvider : IInterestProvider
    {
        private const int GrantPeriodInMonths = 6;

        public decimal CalculateInterest(decimal interestRate, int months)
        {
            months -= IndividualMortgageProvider.GrantPeriodInMonths;
            if (months < 0)
            {
                months = 0;
            }

            return interestRate * months;
        }
    }
}
