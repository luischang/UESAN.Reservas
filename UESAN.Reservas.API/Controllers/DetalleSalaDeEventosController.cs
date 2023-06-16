using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleSalaDeEventosController : ControllerBase
    {
        public readonly IDetalleSalaDeEventosService _service;
        public DetalleSalaDeEventosController(IDetalleSalaDeEventosService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }

        [HttpGet("GetID/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Insert(InsertDetalleSalaDeEventosDTO InsertDetalleSalaDTO)
        {
            var result = await _service.Insert(InsertDetalleSalaDTO);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Update(DetalleSalaDeEventosDTO detalleSalaDeEventosDTO)
        {

            var result = await _service.Update(detalleSalaDeEventosDTO);
            if (!result)
                return BadRequest();

            return Ok(result);



        }
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
