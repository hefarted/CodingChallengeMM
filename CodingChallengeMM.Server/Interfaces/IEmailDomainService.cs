namespace CodingChallengeMM.Server.Interfaces
{
    public interface IEmailDomainService
    {
        bool IsEmailDomainBlacklisted(string email);

    }
}
