namespace CodingChallengeMM.Server.Interfaces
{
    public interface ILoanProductStrategy
    {
        int MinimumTermMonths { get; }
        bool IsInterestFree(int month);
        decimal CalculateFinanceAmount(decimal initialAmount, int termMonths);
    }

}
