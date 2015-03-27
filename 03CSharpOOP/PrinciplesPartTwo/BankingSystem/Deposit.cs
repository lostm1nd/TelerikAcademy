namespace BankingSystem
{
    public class Deposit : Account
    {
        private const decimal InterestThreshold = 1000;

        public override decimal CalculateInterest(IInterestProvider provider, int months)
        {
            if (this.Balance < Deposit.InterestThreshold)
            {
                return 0;
            }

            return base.CalculateInterest(provider, months);
        }
    }
}
