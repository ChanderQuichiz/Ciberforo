using ciberforo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicReactionController : ControllerBase
    {
        private readonly ITopicReactionService topicReactionService;

        public TopicReactionController(ITopicReactionService topicReactionService)
        {
            this.topicReactionService = topicReactionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.TopicReactionDto>> GetTopicReaction(int id)
        {
            var reaction = await topicReactionService.FindById(id);
            return reaction != null ? Ok(reaction) : NotFound("Reaccion no encontrada");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dtos.TopicReactionDto>> create([FromBody] Dtos.TopicReactionCreateDto dto)
        {
            var reaction = await topicReactionService.Create(dto);
            if (reaction == null)
            {
                return BadRequest("Error al crear la reaccion");
            }
            return CreatedAtAction(nameof(GetTopicReaction), new { id = reaction.Id }, reaction);
        }

        [HttpPost("toggle")]
        public async Task<ActionResult<string>> toggle([FromBody] Dtos.TopicReactionCreateDto dto)
        {
            var result = await topicReactionService.toggleReaction(dto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var deleted = await topicReactionService.Delete(id);
            if (!deleted)
            {
                return NotFound("Reaccion no encontrada");
            }
            return Ok("Reaccion eliminada correctamente");
        }
    }
}
