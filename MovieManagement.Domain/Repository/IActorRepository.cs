using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Repository
{
    public interface IActorRepository :IGenericRepository<Actor>
    {
        void Update(Actor actor);
    }
}
