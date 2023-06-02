using Microsoft.AspNetCore.Mvc;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly ICalificacionService calificacionService;

        public CalificacionController(ICalificacionService calificacionService)
        {
            this.calificacionService = calificacionService;
        }

        [HttpGet("{id}")]
        public IActionResult GetCalificacion(int id)
        {
            var calificacion = calificacionService.GetCalificacionById(id);

            if (calificacion == null)
                return NotFound();

            return Ok(calificacion);
        }

        [HttpPost]
        public IActionResult GuardarCalificacion([FromBody] CalificacionDTO calificacionDTO)
        {
            var nuevaCalificacion = calificacionService.GuardarCalificacion(calificacionDTO);
            return CreatedAtAction(nameof(GetCalificacion), new { id = nuevaCalificacion.IdCalificacion }, nuevaCalificacion);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarCalificacion(int id, [FromBody] CalificacionDTO calificacionDTO)
        {
            if (id != calificacionDTO.IdCalificacion)
                return BadRequest();

            var calificacionExistente = calificacionService.GetCalificacionById(id);

            if (calificacionExistente == null)
                return NotFound();

            calificacionService.ActualizarCalificacion(calificacionDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCalificacion(int id)
        {
            var calificacionExistente = calificacionService.GetCalificacionById(id);

            if (calificacionExistente == null)
                return NotFound();

            calificacionService.EliminarCalificacion(id);

            return NoContent();
        }
    }
}
