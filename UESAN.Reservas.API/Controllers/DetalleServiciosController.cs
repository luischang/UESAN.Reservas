using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DetalleServiciosController : ControllerBase
    {
        private readonly IDetalleServiciosService _detalleServiciosService;
        public DetalleServiciosController(IDetalleServiciosService detalleServiciosService)
        {
            _detalleServiciosService = detalleServiciosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var detalleServicios = await _detalleServiciosService.GetAll();
            return Ok(detalleServicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detalleServicios = await _detalleServiciosService.GetById(id);
            if (detalleServicios == null)
                return NotFound();

            return Ok(detalleServicios);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(DetalleServiciosInsertDTO detalleServicios)
        {
            var result = await _detalleServiciosService.Insert(detalleServicios);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DetalleServiciosDescriptionDTO detalleServicios)
        {
            if (id != detalleServicios.IdReserva)
                return NotFound();

            var result = await _detalleServiciosService.Update(detalleServicios);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _detalleServiciosService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}