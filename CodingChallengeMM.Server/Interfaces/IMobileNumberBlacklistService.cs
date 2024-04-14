namespace CodingChallengeMM.Server.Interfaces
{
    public interface IMobileNumberBlacklistService
    {
        bool IsBlacklisted(string mobileNumber);
    }
}
