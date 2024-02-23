using Microsoft.EntityFrameworkCore;

namespace Mission06_Graham.Models
{
    public class EnterMovieContext : DbContext // Database context for the application
    {
        public EnterMovieContext(DbContextOptions<EnterMovieContext> options) : base(options) // Constructor
        {
        }

        public DbSet<EnterMovie> Movies { get; set; } // Table for movies
        public DbSet<Category> Categories { get; set; } // Table for categories

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seed data
        {
            modelBuilder.Entity<Category>().HasData( // Seed categories
                new Category { CategoryId = 1, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
        }
    }
}
