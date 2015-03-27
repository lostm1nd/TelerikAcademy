namespace BankingSystemTest
{
    using System;
    using BankingSystem;

    public class Start
    {
        public static void Main()
        {
            Loan individualLoad = new Loan()
            {
                Balance = 1505.20m,
                Customer = new Individual(),
                MonthlyInterestRate = 12.3m
            };

            var individualLoanInterestForSixMonths = individualLoad.CalculateInterest(new IndividualLoanProvider(), 6);
            Console.WriteLine("12.3 * 6 = " + 12.3m * 6);
            Console.WriteLine("12.3 * (6-3) = " + individualLoanInterestForSixMonths);

            Mortgage individualMortgage = new Mortgage()
            {
                Balance = 123.123m,
                Customer = new Individual(),
                MonthlyInterestRate = 9.5m
            };

            var individualMortgageInterestForEightMonths = individualMortgage.CalculateInterest(new IndividualMortgageProvider(), 8);
            Console.WriteLine("9.5 * 8 = " + 9.5m * 8);
            Console.WriteLine("9.5 * (8-6) = " + individualMortgageInterestForEightMonths);
        }
    }
}
