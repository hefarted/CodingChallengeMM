namespace CodingChallengeMM.Server.Model.Dto
{

    /// <summary>
    /// The customer request create model.
    /// </summary>
    public class CustomerRequestCreateModel
    {
        public decimal AmountRequired { get; set; } // Changed to decimal
        public int Term { get; set; } // Changed to int
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; } // Stays as string but will be validated
        public string Email { get; set; }
    }

}
