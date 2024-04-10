using CodingChallengeMM.Server.Interfaces;

namespace CodingChallengeMM.Server.Strategies
{
    public class ProductBStrategy : ILoanProductStrategy
    {
        public int MinimumTermMonths => 6;
        public bool IsInterestFree(int month) => month <= 2;

        public decimal CalculateFinanceAmount(decimal initialAmount, int termMonths)
        {
            // Example logic for Product B
            var interestRate = 0.05m; // 5% interest rate for simplicity
            var interestFreeAmount = initialAmount; // First 2 months interest-free
            var interestAppliedAmount = initialAmount * (1 + interestRate * (termMonths - 2) / 12);
            return interestFreeAmount + interestAppliedAmount;
        }
    }
}
