using LiterJournal.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LiterJournal.MVC.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<BookActivity> BookActivities { get; set; }

        /// <summary>
        /// Configure the database context options.
        /// </summary>
        /// <param name="optionsBuilder">OptionsBuilder parameter for the DbContext.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(str => Debug.WriteLine(str)); // Log SQL queries to Debug output

            // Use this if you want to enable split queries globally.
            // Alternative: .AsSplitQuery() // Apply only to the specific query
            //optionsBuilder.UseSqlServer(options =>
            //{
            //    options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            //});

        }


        /// <summary>
        /// On model creating override to configure entity relationships and constraints.
        /// </summary>
        /// <param name="builder">Builder parameter for model creation.</param>
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
