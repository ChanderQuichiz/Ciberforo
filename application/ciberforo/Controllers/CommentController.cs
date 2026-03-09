using ciberforo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.CommentDto>> GetComment(int id)
        {
            var comment = await commentService.findById(id);
            return comment != null ? Ok(comment) : NotFound("Comentario no encontrado");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dtos.CommentDto>> create([FromBody] Dtos.CommentCreateDto dto)
        {
            var comment = await commentService.create(dto);
            if (comment == null)
            {
                return BadRequest("Error al crear el comentario");
            }
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Dtos.CommentDto>> update([FromBody] Dtos.CommentUpdateDto dto)
        {
            var comment = await commentService.update(dto);
            if (comment == null)
            {
                return NotFound("Comentario no encontrado");
            }
            return Ok(comment);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var deleted = await commentService.delete(id);
            if (!deleted)
            {
                return NotFound("Comentario no encontrado");
            }
            return Ok("Comentario eliminado correctamente");
        }
    }
}
