using CodingChallengeMM.Server.Interfaces;

namespace CodingChallengeMM.Server.Strategies
{
    public class ProductBStrategy : ILoanProductStrategy
    {
        public int MinimumTermMonths => 6;
        public decimal AnnualInterestRate => 0.05m; // 5% annual interest rate

        public bool IsInterestFree(int month) => month <= 2;

        public decimal CalculateFinanceAmount(decimal initialAmount, int termMonths)
        {
            // No interest is applied if the term is within the interest-free period
            if (termMonths <= 2)
            {
                return initialAmount;
            }

            // Calculate interest for the term after the interest-free period
            int interestApplyingMonths = termMonths - 2;
            decimal monthlyInterestRate = AnnualInterestRate / 12;
            decimal interestAppliedAmount = initialAmount * (decimal)Math.Pow(1 + (double)monthlyInterestRate, interestApplyingMonths);

            // Subtract the initial amount to get the total interest accrued
            decimal totalInterest = interestAppliedAmount - initialAmount;

            // The finance amount is the initial amount plus total interest accrued after the interest-free period
            decimal financeAmount = initialAmount + totalInterest;
            return financeAmount;
        }
    }
}
