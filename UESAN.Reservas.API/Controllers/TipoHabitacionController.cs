using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Core.Services;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly ITipoHabitacionService _tipoHabitacionService;
        public TipoHabitacionController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var tipoHabitacion = await _tipoHabitacionService.GetAll();
            return Ok(tipoHabitacion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _tipoHabitacionService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TipoHabitacionInsertDTO tipoHabitacionInsertDTO)
        {
            var result = await _tipoHabitacionService.Insert(tipoHabitacionInsertDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{idUpdate}")]
        public async Task<IActionResult> Update(TipoHabitacionDescriptionDTO tipoHabitacionDescriptionDTO)
        {
            var result = await _tipoHabitacionService.Update(tipoHabitacionDescriptionDTO);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tipoHabitacionService.Delete(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
