namespace CodingChallengeMM.Server.Model.Entities
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public decimal AmountRequired { get; set; } // Changed to decimal
        public int Term { get; set; } // Changed to int
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; } // Stays as string but will be validated
        public string Email { get; set; }

        public Finance FinanceDetails { get; set; }
    }
}
