using Microsoft.EntityFrameworkCore;
using DTO;

namespace Repository
{
   
    // Your DbContext class
    public class CrudApplicationDbContext : DbContext
    {
        public CrudApplicationDbContext(DbContextOptions<CrudApplicationDbContext> options): base(options)
        {

        }
        public DbSet<User>? Users { get; set; }
        public DbSet<UserProfile>? UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.UserId).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u=>u.Username).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u=>u.PersonalNumber).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u => u.UserProfileId).IsUnique();
            modelBuilder.Entity<UserProfile>().HasIndex(u => u.UserId).IsUnique();
        }
    }
}
