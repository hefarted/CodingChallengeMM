using CodingChallengeMM.Server.Data;
using CodingChallengeMM.Server.Interfaces;

namespace CodingChallengeMM.Server.Services
{
    public class MobileNumberBlacklistService : IMobileNumberBlacklistService
    {
        private readonly ApplicationDbContext _context;

        public MobileNumberBlacklistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsBlacklisted(string mobileNumber)
        {
            return _context.BlacklistedNumbers.Any(b => b.MobileNumber == mobileNumber);
        }
    }
}
