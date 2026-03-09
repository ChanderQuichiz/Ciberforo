using ciberforo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService topicService;

        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.TopicDto>> GetTopic(int id)
        {
            var topic = await topicService.FindById(id);
            return topic != null ? Ok(topic) : NotFound("Tema no encontrado");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dtos.TopicDto>> create([FromBody] Dtos.TopicCreateDto dto)
        {
            var topic = await topicService.Create(dto);
            if (topic == null)
            {
                return BadRequest("Error al crear el tema");
            }
            return CreatedAtAction(nameof(GetTopic), new { id = topic.Id }, topic);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Dtos.TopicDto>> update([FromBody] Dtos.TopicUpdateDto dto)
        {
            var topic = await topicService.Update(dto);
            if (topic == null)
            {
                return NotFound("Tema no encontrado");
            }
            return Ok(topic);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var deleted = await topicService.Delete(id);
            if (!deleted)
            {
                return NotFound("Tema no encontrado");
            }
            return Ok("Tema eliminado correctamente");
        }
    }
}
