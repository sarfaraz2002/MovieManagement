using AutoMapper;
using MovieManagement.DataAccess.DataContext;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementaions
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly MovieManagementDbContext _context;
        public UnitOfWork(MovieManagementDbContext context,IMapper mapper)
        {
            _context = context;
            Actor = new ActorRepository(_context);
            Movies = new MovieRepository(_context);
        }
        public IActorRepository Actor { get; private set; }

        public IMoviesRepository Movies { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
           return _context.SaveChanges();
        }
    }
}
