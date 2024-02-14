using MovieManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Dtos.ReqDtos
{
    public class MovieReqDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ActorId { get; set; }
        public int GenreId {  get; set; }

        public Language Language { get; set; }
        public Rating Rating { get; set; }
    }
}
