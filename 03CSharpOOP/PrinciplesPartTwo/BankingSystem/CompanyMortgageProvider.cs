namespace BankingSystem
{
    public class CompanyMortgageProvider : IInterestProvider
    {
        private const int PeriodWithHalfInterestInMonths = 12;

        public decimal CalculateInterest(decimal interestRate, int months)
        {
            int periodWithFullInterest = months;
            int periodWithHalfInterest = 0;

            if (months <= CompanyMortgageProvider.PeriodWithHalfInterestInMonths)
            {
                periodWithFullInterest = 0;
                periodWithHalfInterest = months;
            }
            else
            {
                periodWithFullInterest = months - CompanyMortgageProvider.PeriodWithHalfInterestInMonths;
                periodWithHalfInterest = CompanyMortgageProvider.PeriodWithHalfInterestInMonths;
            }

            return (interestRate * periodWithFullInterest) + ((interestRate / 2) * periodWithHalfInterest);
        }
    }
}
