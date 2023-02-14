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

        public DbSet<Movie> MovieResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(

                // Creating Seed Movies
                new Movie
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13"
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Scott Pilgrim vs. the World",
                    Year = 2010,
                    Director = "Edgar Wright",
                    Rating = "PG-13"
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Action/Adventure",
                    Title = "Star Wars Episode III: Revenge of the Sith",
                    Year = 2005,
                    Director = "George Lucas",
                    Rating = "PG-13"
                });
        }
    }
}
