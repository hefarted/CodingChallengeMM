using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallengeMM.Server.Model
{
    public class FinanceCreateModel
    {
        public decimal Amount { get; set; }
        public int TermInMonths { get; set; }
        public decimal RepaymentAmount { get; set; }
        public string RepaymentFrequency { get; set; }

        // Foreign key to relate to the CustomerRequest
        [ForeignKey("CustomerRequest")]
        public int CustomerRequestId { get; set; }

    }
}
