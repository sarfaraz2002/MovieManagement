using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MovieManagement.DataAccess.Service.MovieService;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;

namespace MovieManagement.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MovieController:ODataController
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        [EnableQuery]
        public ActionResult Get()
        {
            var movie = _movieService.GetAll();
            return Ok(movie);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] MovieReqDto movie)
        {

            try
            {
                _movieService.AddMovie(movie);
                return Ok("Movie updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] MovieReqDto movieUpdateRequest)
        {
            try
            {
                _movieService.UpdateMovie(id, movieUpdateRequest);
                return Ok("Movie updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
