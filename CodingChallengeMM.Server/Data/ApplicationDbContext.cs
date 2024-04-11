
namespace CodingChallengeMM.Server.Data
{
    using CodingChallengeMM.Server.Model.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerRequest> CustomerRequests { get; set; }

        public DbSet<BlacklistedDomain> BlacklistedDomains { get; set; }

        public DbSet<BlacklistedNumber> BlacklistedNumbers { get; set; }


        public DbSet<Finance> Finance { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.AmountRequired)
                      .IsRequired()
                      .HasColumnType("decimal(18, 2)"); // Precision suitable for money

                entity.Property(e => e.Term)
                      .IsRequired(); // Assuming Term is always required and represents a whole number

                entity.Property(e => e.Title).HasMaxLength(10);

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Mobile)
                      .IsRequired()
                      .HasMaxLength(20);
                // Consider custom validation for format if necessary

                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);

                entity.HasIndex(e => e.Email).IsUnique();
            });



            modelBuilder.Entity<CustomerRequest>()
          .HasOne(cr => cr.FinanceDetails)
          .WithOne(f => f.CustomerRequest)
          .HasForeignKey<Finance>(f => f.CustomerRequestId);
        }

    }
}
