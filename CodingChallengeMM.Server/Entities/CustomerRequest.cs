namespace CodingChallengeMM.Server.Entities
{
    public class CustomerRequest
    {
        public int Id { get; set; } // Primary Key
        public string AmountRequired { get; set; }
        public string Term { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public Finance FinanceDetails { get; set; }
    }
}
