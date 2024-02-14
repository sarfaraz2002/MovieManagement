using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Service.MovieService
{
    public interface IMovieService
    {
        IEnumerable<MovieResDto> GetAll();
        void AddMovie(MovieReqDto movieReqDto);
        void UpdateMovie(int id, MovieReqDto movieUpdateRequest);
        MovieResDto GetById(int id);
    }
}
