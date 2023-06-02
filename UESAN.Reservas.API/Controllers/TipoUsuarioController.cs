using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _tipoUsuarioService;

        public TipoUsuarioController(ITipoUsuarioService tipoUsuarioService)
        {
            //_categoryRepository = categoryRepository;
            _tipoUsuarioService = tipoUsuarioService;
        }

        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var tipousuario = await _tipoUsuarioService.GetAll();
            return Ok(tipousuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipousuario = await _tipoUsuarioService.GetById(id);
            if (tipousuario == null)
                return NotFound();

            return Ok(tipousuario);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(InsertTipoUsuarioDTO insertipoUsuarioDTO)
        {
            var result = await _tipoUsuarioService.Insert(insertipoUsuarioDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Update(int id, TipoUsuarioDTO tipoUsuario)
        {
            if (id != tipoUsuario.IdTipo)
                return NotFound();

            var result = await _tipoUsuarioService.Update(tipoUsuario);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tipoUsuarioService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
