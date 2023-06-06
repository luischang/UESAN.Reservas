using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var servicio = await _servicioService.GetAll();
            return Ok(servicio);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var servicio = await _servicioService.GetById(id);
            if (servicio == null)
                return NotFound();

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ServicioInsertDTO servicio)
        {
            var result = await _servicioService.Insert(servicio);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ServicioDescriptionDTO servicio)
        {
            if (id != servicio.IdServicio)
                return NotFound();

            var result = await _servicioService.Update(servicio);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _servicioService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
