using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleReservaController : ControllerBase

    {
        private readonly IDetalleReservaService _service;
        public DetalleReservaController(IDetalleReservaService detalleReservaService)
        {
            _service = detalleReservaService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var empresa = await _service.GetAll();
            return Ok(empresa);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DetalleReservasInsertDTO detalleReservas)
        {
            var result = await _service.Insert(detalleReservas);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(DetalleReservaDescriptionDTO detalleReservas)
        {
            
                var result = await _service.Update(detalleReservas);
                if (!result)
                    return BadRequest();

                return Ok(result);
            
           
           
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete (id);
            if (!result)
                return BadRequest();

            return NoContent();
        }

    }
}
