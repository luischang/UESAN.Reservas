using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Core.Services;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaDeEventosController : ControllerBase
    {
        private readonly ISalaDeEventosService _salaDeEventosService;

        public SalaDeEventosController(ISalaDeEventosService salaDeEventosService)
        {
            _salaDeEventosService = salaDeEventosService;
        }
        [HttpGet("Traer")]
        public async Task<IActionResult> GetAll()
        {
            var salaEvento = await _salaDeEventosService.GetAll();
            return Ok(salaEvento);
        }
        [HttpGet("TraerId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ofertas = await _salaDeEventosService.GetById(id);
            if (ofertas == null)
                return NotFound();

            return Ok(ofertas);
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Insert(InsertSalaDeEventosDTO insertSalaDeEventosDTO)
        {
            var result = await _salaDeEventosService.Insert(insertSalaDeEventosDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Update(int id, SalaDeEventosDTO salaDeEventosDTO)
        {
            if (id != salaDeEventosDTO.IdSalaEvento)
                return NotFound();

            var result = await _salaDeEventosService.Update(salaDeEventosDTO);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _salaDeEventosService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
