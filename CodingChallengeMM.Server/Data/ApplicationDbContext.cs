
namespace CodingChallengeMM.Server.Data
{
    using CodingChallengeMM.Server.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerRequest> CustomerRequests { get; set; }

        public DbSet<BlacklistedDomain> BlacklistedDomains { get; set; }


        public DbSet<Finance> Finance { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRequest>()
          .HasOne(cr => cr.FinanceDetails)
          .WithOne(f => f.CustomerRequest)
          .HasForeignKey<Finance>(f => f.CustomerRequestId);
        }

    }
}
