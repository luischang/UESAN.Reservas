using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;
<<<<<<< HEAD
=======

>>>>>>> Ultimos Cambios
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

<<<<<<< HEAD


=======
        [HttpGet("{id}")]
        public IActionResult GetCalificacion(int id)
        {
            //Todo: Pendiente GetCalifiacionById en el Service
            //var calificacion = calificacionService.GetCalificacionById(id);

            //if (calificacion == null)
            //    return NotFound();

            return Ok(/*calificacion*/);
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
            //Todo: Pendiente GetCalifiacionById en el Service
            //var calificacionExistente = calificacionService.GetCalificacionById(id);

            //if (calificacionExistente == null)
            //    return NotFound();

            ////Todo: Pendiente ActualizarCalificacion en el service
            //calificacionService.ActualizarCalificacion(calificacionDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCalificacion(int id)
        {
            //Todo: Pendiente GetCalifiacionById en el Service
            //var calificacionExistente = calificacionService.GetCalificacionById(id);

            //if (calificacionExistente == null)
            //    return NotFound();

            //Todo: Pendiente EliminarCalificacionID en el Service
            //calificacionService.EliminarCalificacion(id);

            return NoContent();
        }
>>>>>>> Ultimos Cambios
    }
}
