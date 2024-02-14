using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Dtos.ResDtos
{
    public class MovieResDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public GenreResDto Genre { get; set; }
        public string Rating { get; set; }
        public string Language { get; set; }
    }
}
