namespace CodingChallengeMM.Server.Data
{
    using CodingChallengeMM.Server.Model;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerRequest> CustomerRequests { get; set; }

        public DbSet<BlacklistedDomain> BlacklistedDomains { get; set; }

    }
}
