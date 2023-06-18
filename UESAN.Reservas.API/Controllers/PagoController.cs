
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pagos = await _pagoService.GetAll();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pago = await _pagoService.GetById(id);
            if (pago == null)
                return NotFound();
            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PagoInsertDTO pago)
        {
            var result = await _pagoService.Insert(pago);
            if (!result)
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PagoDescripcionDTO pago)
        {
            if (id != pago.IdPago)
                return NotFound();

            var result = await _pagoService.Update(pago);
            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pagoService.Delete(id);
            if (!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
