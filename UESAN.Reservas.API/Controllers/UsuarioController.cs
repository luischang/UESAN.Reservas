using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuarioAuthenticationDTO usuarioDTO)
        {
            var result = await _usuarioService.Validate(usuarioDTO.Email, usuarioDTO.Contraseña);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UsuarioAuthRequestDTO userDTO)
        {
            var result = await _usuarioService.Register(userDTO);
            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Usuario(int idUsuario)
        {
            var result = await _usuarioService.GetById(idUsuario);


            return Ok(result);
        }
    }
}
