namespace BankingSystem
{
    public class IndividualLoanProvider : IInterestProvider
    {
        private const int GrantPeriodInMonths = 3;

        public decimal CalculateInterest(decimal interestRate, int months)
        {
            months -= IndividualLoanProvider.GrantPeriodInMonths;
            if (months < 0)
            {
                months = 0;
            }

            return interestRate * months;
        }
    }
}
