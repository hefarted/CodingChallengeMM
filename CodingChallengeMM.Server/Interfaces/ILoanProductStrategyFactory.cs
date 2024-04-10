namespace CodingChallengeMM.Server.Interfaces
{
    public interface ILoanProductStrategyFactory
    {
        ILoanProductStrategy GetStrategy(string productType);
    }

}
