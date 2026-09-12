using CostTrackerAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CostTrackerAPI.Data
{
    public class CostTrackerAPIDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public CostTrackerAPIDBContext(DbContextOptions<CostTrackerAPIDBContext> options) : base(options)
        {

        }

        DbSet<Subscription> Subscriptions { get; set; }
        DbSet<CostHistory> CostHistories { get; set; }
        DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configure the relationships between User and Subscription
            builder.Entity<User>()
                .HasMany(u => u.UserSubscriptions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            // Configure the relationships between User and CostHistory
            builder.Entity<User>()
                .HasMany(u => u.UserCostHistory)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            // Configure the relationships between User and Category
            builder.Entity<User>()
                .HasMany(u => u.UserCategories)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
