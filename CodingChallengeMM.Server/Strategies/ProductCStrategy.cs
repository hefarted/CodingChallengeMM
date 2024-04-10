using CodingChallengeMM.Server.Interfaces;

namespace CodingChallengeMM.Server.Strategies
{

    public class ProductCStrategy : ILoanProductStrategy
    {
        public int MinimumTermMonths => 1;
        public bool IsInterestFree(int month) => false;

        public decimal CalculateFinanceAmount(decimal initialAmount, int termMonths)
        {
            // Assuming constant interest rate for simplicity
            var interestRate = 0.07m; // 7% interest rate
            return initialAmount * (1 + interestRate * termMonths / 12);
        }
    }
}
