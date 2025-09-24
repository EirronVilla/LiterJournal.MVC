using LiterJournal.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiterJournal.MVC.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<BookActivity> BookActivities { get; set; }

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

            builder.Entity<UserBook>()
                .HasOne(ub => ub.UserProfile)
                .WithMany(up => up.UserBooks)
                .HasForeignKey(ub => ub.UserProfileId);

            builder.Entity<UserBook>()
                .HasOne(ub => ub.Book)
                .WithMany()
                .HasForeignKey(ub => ub.BookId);

            builder.Entity<BookActivity>()
                .HasOne(ba => ba.UserBook)
                .WithMany(ub => ub.BookActivities)
                .HasForeignKey(ba => ba.UserBookId);
        }
    }
}
