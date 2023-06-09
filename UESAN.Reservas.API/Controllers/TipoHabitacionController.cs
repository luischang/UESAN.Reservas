using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.Interfaces;

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
    }
}
