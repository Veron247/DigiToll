using DigiToll.DataStorage.EntityConfigurations.AccountManagement;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigiToll.DataStorage.DatabaseContext;

public class AccountDbContext : IdentityDbContext<ApplicationUser>
{
    
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }
    public DbSet<Audit> Audits { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
    {
        modelBuilder.Properties<decimal>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Audit>()
            .HasOne(a => a.ApplicationUser)
            .WithMany(u => u.Audit)
            .HasForeignKey(a => a.AppUserId);
    }
}
