namespace CodingChallengeMM.Server.Model.Responses
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public ErrorDetail Error { get; set; }
    }
}
