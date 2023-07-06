using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionService _calificacionService;

        public CalificacionController(ICalificacionService calificacionService)
        {
            _calificacionService = calificacionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var calificaciones = await _calificacionService.GetAll();
            return Ok(calificaciones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var calificacion = await _calificacionService.GetById(id);
            if (calificacion == null)
                return NotFound();

            return Ok(calificacion);
        }

        [HttpGet("CalificacionUsuario")]
        public async Task<IActionResult> CalificacionPorUsuario(int idUsuario)
        {
            
            var calificacion = await _calificacionService.GetAll();


            return Ok(calificacion);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(CalificacionInsertDTO calificacion)
        {
            var result = await _calificacionService.Insert(calificacion);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CalificacionRecomendacionDTO calificacion)
        {
            if (id != calificacion.IdCalificacion)
                return NotFound();

            var result = await _calificacionService.Update(calificacion);
            if (!result)
                return BadRequest();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _calificacionService.Delete(id);
            if (!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
