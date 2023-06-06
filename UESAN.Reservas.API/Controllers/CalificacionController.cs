using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;
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

      
        [HttpPost]
        public IActionResult GuardarCalificacion([FromBody] CalificacionDTO calificacionDTO)
        {
            var nuevaCalificacion = calificacionService.GuardarCalificacion(calificacionDTO);
            return CreatedAtAction(nameof(GetCalificacion), new { id = nuevaCalificacion.IdCalificacion }, nuevaCalificacion);
        }

        

        
}
