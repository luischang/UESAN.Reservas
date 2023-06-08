using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _service= detalleReservaService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var empresa = await _service.GetAll();
            return Ok(empresa);
        }

        [HttpGet("{idEmpresa}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
