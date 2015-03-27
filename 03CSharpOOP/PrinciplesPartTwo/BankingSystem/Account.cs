namespace BankingSystem
{
    public abstract class Account
    {
        public Customer Customer { get; set; }

        public decimal Balance { get; set; }

        public decimal MonthlyInterestRate { get; set; }

        public virtual decimal CalculateInterest(IInterestProvider provider, int months)
        {
            return provider.CalculateInterest(this.MonthlyInterestRate, months);
        }
    }
}
