using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IActorRepository Actor { get; }
        IMoviesRepository Movies { get; }
        int Save();
    }
}
