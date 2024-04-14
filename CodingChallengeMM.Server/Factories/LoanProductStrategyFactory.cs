using CodingChallengeMM.Server.Interfaces;
using CodingChallengeMM.Server.Strategies;

namespace CodingChallengeMM.Server.Factories
{
    public class LoanProductStrategyFactory : ILoanProductStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public LoanProductStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ILoanProductStrategy GetStrategy(string productType)
        {
            switch (productType)
            {
                case "ProductA":
                    return _serviceProvider.GetRequiredService<ProductAStrategy>();
                case "ProductB":
                    return _serviceProvider.GetRequiredService<ProductBStrategy>();
                case "ProductC":
                    return _serviceProvider.GetRequiredService<ProductCStrategy>();
                default:
                    throw new ArgumentException($"Unsupported product type: {productType}", nameof(productType));
            }
        }

        // to do.
        public decimal CalculateWeeklyRepayment(decimal financeAmount, int termMonths, decimal annualInterestRate)
        {
            int weeksPerYear = 52;
            int weeksPerMonth = 4; // Approximate value

            decimal weeklyInterestRate = annualInterestRate / weeksPerYear;
            int totalPayments = termMonths * weeksPerMonth;

            decimal weeklyRepayment = financeAmount *
                (weeklyInterestRate *
            (decimal)Math.Pow((double)(1 + weeklyInterestRate), totalPayments)) /
            ((decimal)Math.Pow((double)(1 + weeklyInterestRate), totalPayments) - 1);

            return weeklyRepayment;
        }
    }
}



