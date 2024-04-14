using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallengeMM.Server.Model.Dto
{
    public class FinanceCreateModel
    {

        public string ProductType { get; set; }

        // Foreign key to relate to the CustomerRequest
        [ForeignKey("CustomerRequest")]
        public int CustomerRequestId { get; set; }

    }
}
