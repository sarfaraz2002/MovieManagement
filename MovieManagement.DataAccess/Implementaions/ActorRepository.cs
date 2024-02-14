using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.DataContext;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using AutoMapper;

namespace MovieManagement.DataAccess.Implementaions
{
    public class ActorRepository:GenericRepository<Actor> ,IActorRepository
    {
        public readonly MovieManagementDbContext _context;

        public ActorRepository(MovieManagementDbContext context) :base(context) 
        {
            _context = context;
        }
        
        public new IEnumerable<Actor> GetAll()
        {
            try
            {
                var actors = _context.Actors.Include(u => u.Movies).ThenInclude(m => m.Genre).Include(u => u.Biography).ToList();
                return actors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving actors: {ex.Message}");
                throw;
            }
        }

        public new Actor GetById(int id)
        {
            try
            {
                var actor = _context.Actors
                .Include(a => a.Movies)
                    .ThenInclude(m => m.Genre)
                .Include(a => a.Biography)
                .FirstOrDefault(a => a.Id == id);

                return actor;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving actors: {ex.Message}");
                throw;
            }
        }

        public void Update(Actor actor)
        {
            _context.Actors.Update(actor);
        }
    }
}
