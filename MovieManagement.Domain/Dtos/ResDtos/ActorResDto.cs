using MovieManagement.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Dtos.ResDtos
{
    public class ActorResDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<MovieResDto>? Movies { get; set; }

        public BiographyResDto Biography { get; set; }

    }
}
