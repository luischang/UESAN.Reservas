using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdEstadoReservaController : ControllerBase
    {
        private readonly IIdEstadoReservaService _idEstadoReservaService;
        public IdEstadoReservaController(IIdEstadoReservaService idEstadoReservaService)
        {
            _idEstadoReservaService = idEstadoReservaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var idEstadoReserva = await _idEstadoReservaService.GetAll();
            return Ok(idEstadoReserva);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var idEstadoReserva = await _idEstadoReservaService.GetById(id);
            if (idEstadoReserva == null)
                return NotFound();

            return Ok(idEstadoReserva);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(IdEstadoReservaInsertDTO idEstadoReserva)
        {
            var result = await _idEstadoReservaService.Insert(idEstadoReserva);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, IdEstadoReservaDescriptionDTO idEstadoReserva)
        {
            if (id != idEstadoReserva.IdEstadoRes)
                return NotFound();

            var result = await _idEstadoReservaService.Update(idEstadoReserva);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _idEstadoReservaService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}