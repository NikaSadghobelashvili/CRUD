using DTO;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CrudApplicationDbContext : DbContext
    {
        public CrudApplicationDbContext(DbContextOptions<CrudApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserId).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u => u.PersonalNumber).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u => u.UserProfileId).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u => u.UserId).IsUnique();
        }
    }
}
