using AutoMapper;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Service.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddMovie(MovieReqDto movieReqDto)
        {
            try
            {
                var movie = _mapper.Map<Movie>(movieReqDto);
                _unitOfWork.Movies.Add(movie);
                _unitOfWork.Save();
            }
            catch { }
        }

        public IEnumerable<MovieResDto> GetAll()
        {
            var movies = _unitOfWork.Movies.GetAll();
            var moviesDto = _mapper.Map<List<MovieResDto>>(movies);
            return moviesDto;
        }

        public MovieResDto GetById(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }
            var moviesDto = _mapper.Map<MovieResDto>(movie);
            return moviesDto;
        }

        public void UpdateMovie(int id, MovieReqDto movieUpdateRequest)
        {
            var movie = _unitOfWork.Movies.GetById(id);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found");
            }
            movie.ActorId = movieUpdateRequest.ActorId;
            movie.Rating = movieUpdateRequest.Rating;
            movie.Name = movieUpdateRequest.Name;
            movie.Description = movieUpdateRequest.Description;
            movie.Language = movieUpdateRequest.Language;
            movie.GenreId = movieUpdateRequest.GenreId;

            _unitOfWork.Movies.Update(movie);
            _unitOfWork.Save();
        }
    }
}
