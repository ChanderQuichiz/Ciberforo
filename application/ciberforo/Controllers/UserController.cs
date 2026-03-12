using ciberforo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ciberforo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Dtos.UserDto>> GetUser(int id)
        {
            var user = await userService.findById(id);
            
            return user != null? Ok(user): NotFound("Usuario no encontrado");
        }

        [HttpPost("create")]
        public async Task<ActionResult<Dtos.UserDto>> create([FromBody]Dtos.UserCreateDto dto)
        {
            var user = await userService.create(dto);
        if (user == null)
            {
                return BadRequest("Error al crear el usuario");
            }
          return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<Dtos.UserDto>> login([FromBody]Dtos.UserLoginDto dto)
        {
            var user = await userService.login(dto);
            if (user == null)
            {
                return Unauthorized("Credenciales inválidas");
            }
            return Ok(user);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Dtos.UserDto>> update([FromBody] Dtos.UserUpdateDto dto)
        {
            var user = await userService.update(dto);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }
            return NotFound(user);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var deleted = await userService.delete(id);
            if (!deleted)
            {
                return NotFound("Usuario no encontrado");
            }
            return NoContent();
        }

        [HttpPatch("ban/{id}")]
        public async Task<ActionResult> ban(int id)
        {
            var banned = await userService.banned(id);
            if (!banned)
            {
                return NotFound("Usuario no encontrado");
            }
            return NoContent();
        }
    }
}
