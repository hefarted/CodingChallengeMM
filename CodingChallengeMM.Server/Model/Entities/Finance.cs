using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallengeMM.Server.Model.Entities
{

    public class Finance
    {
        public int Id { get; set; } // Primary key for the Finance table
        public decimal RepaymentAmount { get; set; }
        public int RepaymentFrequency { get; set; }

        public string ProductType { get; set; }

        // Foreign key to relate to the CustomerRequest
        [ForeignKey("CustomerRequest")]
        public int CustomerRequestId { get; set; }

        public decimal FinanceAmount { get; set; }
        public int TermMonths { get; set; } // The duration over which the amount is financed
        public decimal WeeklyRepaymentAmount { get; set; }
        public decimal TotalRepaymentAmount { get; set; } // Total amount after adding fees and interest
        public decimal EstablishmentFee { get; set; }
        public decimal InterestAmount { get; set; } // Total interest amount

        public CustomerRequest CustomerRequest { get; set; }
    }

}
