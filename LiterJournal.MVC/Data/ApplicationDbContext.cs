using LiterJournal.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiterJournal.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Additional model configuration can go here
            builder.Entity<UserProfile>(
                entity =>
                {
                    entity.HasOne<IdentityUser>()
                    .WithOne()
                    .HasForeignKey<UserProfile>(up => up.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
