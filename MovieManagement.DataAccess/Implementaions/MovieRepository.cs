using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.DataContext;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementaions
{
    public class MovieRepository:GenericRepository<Movie>,IMoviesRepository
    {
        public readonly MovieManagementDbContext _context;
        public MovieRepository(MovieManagementDbContext context) : base(context)
        {
            _context = context;
        }
        public new IEnumerable<Movie> GetAll()
        {
            try
            {
                var movies = _context.Movies.Include(m => m.Genre).ToList();
                return movies;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving movies: {ex.Message}");
                throw;
            }
        }

        public new Movie GetById(int id)
        {
            try
            {
                var movie = _context.Movies
                .Include(m => m.Genre)
                .FirstOrDefault(a => a.Id == id);

                return movie;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving movies: {ex.Message}");
                throw;
            }
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }
    }
}
