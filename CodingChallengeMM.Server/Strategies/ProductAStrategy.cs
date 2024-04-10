using CodingChallengeMM.Server.Interfaces;

namespace CodingChallengeMM.Server.Strategies
{
    public class ProductAStrategy : ILoanProductStrategy
    {
        public int MinimumTermMonths => 1;
        public bool IsInterestFree(int month) => true;

        public decimal CalculateFinanceAmount(decimal initialAmount, int termMonths)
        {
            // Simple example: Product A is interest-free.
            return initialAmount; // No interest applied
        }
    }
}
