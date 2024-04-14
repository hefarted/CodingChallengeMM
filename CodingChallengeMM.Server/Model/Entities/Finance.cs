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

        public CustomerRequest CustomerRequest { get; set; }
    }

}
