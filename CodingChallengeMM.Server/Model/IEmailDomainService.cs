namespace CodingChallengeMM.Server.Model
{
    public interface IEmailDomainService
    {
        bool IsEmailDomainBlacklisted(string email);

    }
}
