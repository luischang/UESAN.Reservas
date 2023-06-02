using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuejasController : ControllerBase
    {
        private readonly IQuejasService _quejasService;

        public QuejasController(IQuejasService quejasService)
        {
            _quejasService = quejasService;
        }

        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var quejas = await _quejasService.GetAll();
            return Ok(quejas);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Insert(InsertQuejasDTO quejas)
        {
            var result = await _quejasService.Insert(quejas);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Update(int id, QuejasDTO quejas)
        {
            if (id != quejas.IdQuejas)
                return NotFound();

            var result = await _quejasService.Update(quejas);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _quejasService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
