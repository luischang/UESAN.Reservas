using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService pagoService;

        public PagoController(IPagoService pagoService)
        {
            this.pagoService = pagoService;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPago(int id)
        {
            var pago = pagoService.ObtenerPago(id);

            if (pago == null)
                return NotFound();

            return Ok(pago);
        }

        [HttpPost]
        public IActionResult GuardarPago([FromBody] PagoDTO pagoDTO)
        {
            var nuevoPago = pagoService.GuardarPago(pagoDTO);
            return CreatedAtAction(nameof(ObtenerPago), new { id = nuevoPago.IdPago }, nuevoPago);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPago(int id, [FromBody] PagoDTO pagoDTO)
        {
            if (id != pagoDTO.IdPago)
                return BadRequest();

            pagoService.ActualizarPago(pagoDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPago(int id)
        {
            pagoService.EliminarPago(id);
            return NoContent();
        }
    }
}
