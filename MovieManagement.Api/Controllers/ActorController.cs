using Microsoft.AspNetCore.Mvc;
using MovieManagement.DataAccess.Implementaions;
using MovieManagement.DataAccess.Service.ActorService;
using MovieManagement.Domain.Dtos.ReqDtos;
using MovieManagement.Domain.Dtos.ResDtos;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;

namespace MovieManagement.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;
        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var actor = _actorService.GetAll();
            return Ok(actor);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var actor = _actorService.GetById(id);
                return Ok(actor);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody] ActorReqDto actor) {

            try
            {
                _actorService.AddActor(actor);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] ActorReqDto actorUpdateRequest)
        {
            try
            {
                _actorService.UpdateActor(id, actorUpdateRequest);
                return Ok("Actor updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
