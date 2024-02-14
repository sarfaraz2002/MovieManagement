using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }=string.Empty;
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre {  get; set; }  
        public Rating Rating { get; set; }
        public Language Language {  get; set; }   
    }
}
