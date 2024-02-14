using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.DataContext
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options): base(options) { }

        public DbSet<Actor> Actors {  get; set; } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Biography> Biographys { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Tom", LastName = "Hanks" },
                new Actor { Id = 2, FirstName = "Meryl", LastName = "Streep" },
                new Actor { Id = 3, FirstName = "Leonardo", LastName = "DiCaprio" },
                new Actor { Id = 4, FirstName = "Charlize", LastName = "Theron" },
                new Actor { Id = 5, FirstName = "Brad", LastName = "Pitt" }
            );
            modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Name = "Action" },
                    new Genre { Id = 2, Name = "Adventure" },
                    new Genre { Id = 3, Name = "Comedy" },
                    new Genre { Id = 4, Name = "Drama" },
                    new Genre { Id = 5, Name = "Fantasy" },
                    new Genre { Id = 6, Name = "Horror" },
                    new Genre { Id = 7, Name = "Mystery" },
                    new Genre { Id = 8, Name = "Romance" },
                    new Genre { Id = 9, Name = "Sci-Fi" },
                    new Genre { Id = 10, Name = "Thriller" }
                );

                modelBuilder.Entity<Movie>().HasData(
     new Movie { Id = 1, Name = "Forrest Gump", Description = "A man with a low IQ accomplishes great things in his life.", ActorId = 1, Rating = Rating.PG13, Language = Language.English, GenreId = 1 },
     new Movie { Id = 2, Name = "The Devil Wears Prada", Description = "A smart but sensible new graduate lands a job as an assistant to Miranda Priestly, the demanding editor-in-chief of a high-fashion magazine.", ActorId = 2, Rating = Rating.PG, Language = Language.English, GenreId = 4 },
     new Movie { Id = 3, Name = "Inception", Description = "A thief who enters the dreams of others to steal their secrets.", ActorId = 3, Rating = Rating.PG13, Language = Language.English, GenreId = 2 },
     new Movie { Id = 4, Name = "Mad Max: Fury Road", Description = "In a post-apocalyptic wasteland, a woman rebels against a tyrannical ruler in search of her homeland.", ActorId = 4, Rating = Rating.R, Language = Language.English, GenreId = 3 },
     new Movie { Id = 5, Name = "Fight Club", Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.", ActorId = 5, Rating = Rating.R, Language = Language.English, GenreId = 4}
 );

        }
    }
}
