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

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<CostHistory> CostHistories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Subscription>()
                .HasOne(s => s.SubscriptionCategory)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<User>()
                .HasMany(u => u.UserSubscriptions)
                .WithOne()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CostHistory>()
                .HasOne<User>()
                .WithMany(u => u.UserCostHistory)
                .HasForeignKey(ch => ch.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
