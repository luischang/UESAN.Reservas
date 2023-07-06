using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservasOrderController : ControllerBase
    {
        private readonly IReservasOrderService _reservasOrderService;
        public ReservasOrderController(IReservasOrderService reservasOrderService)
        {
            _reservasOrderService = reservasOrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservasOrder = await _reservasOrderService.GetAll();
            return Ok(reservasOrder);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservasOrder = await _reservasOrderService.GetById(id);
            if (reservasOrder == null)
                return NotFound();

            return Ok(reservasOrder);
        }

        [HttpGet("ReservasUsuario")]
        public async Task<IActionResult> ReservasPorUsuario(int idUsuario)
        {

            var reservasOrder = await _reservasOrderService.ReservasPorUsuario(idUsuario);
            return Ok(reservasOrder);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Insert(ReservasOrderInsertarDTO reservasOrder)
        {
            var result = await _reservasOrderService.Insert(reservasOrder);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<IActionResult> Update(int id, ReservasOrderDescriptionDTO reservasOrder)
        {
            if (id != reservasOrder.IdReserva)
                return NotFound();

            var result = await _reservasOrderService.Update(reservasOrder);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("Eliminar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservasOrderService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
