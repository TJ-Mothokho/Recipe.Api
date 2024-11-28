using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
            .HasKey(l => new { l.UserID, l.RecipeID }); // Define composite key

            // User-Recipe (One-to-Many)
            modelBuilder.Entity<RecipeModel>()
                .HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict); // OK to cascade

            // Recipe-Category (Many-to-One)
            modelBuilder.Entity<RecipeModel>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // Recipe-Hashtag (Many-to-Many)
            modelBuilder.Entity<RecipeModel>()
                .HasMany(r => r.Hashtags)
                .WithMany(h => h.Recipes)
                .UsingEntity(j => j.ToTable("RecipeHashtags"));

            // Recipe-Comment (One-to-Many)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeID)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascade delete

            // User-Comment (One-to-Many)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Prevent cascading delete to avoid cycles

            // Recipe-Like (One-to-Many)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Recipe)
                .WithMany(r => r.Likes)
                .HasForeignKey(l => l.RecipeID)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascade delete

            // User-Like (One-to-Many)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Prevent cascading delete
        }


        public DbSet<User> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<RecipeModel> Recipes { get; set; }
    }
}
