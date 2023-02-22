using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_mh828.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base (options) {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Creating Seed Categories
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense"},
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );

            // Creating Seed Movies
            mb.Entity<Movie>().HasData(

                
                new Movie
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new Movie
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Scott Pilgrim vs. the World",
                    Year = 2010,
                    Director = "Edgar Wright",
                    Rating = "PG-13"
                },
                new Movie
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13"
                });
        }
    }
}
