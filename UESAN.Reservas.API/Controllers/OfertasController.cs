
using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class OfertasController : ControllerBase
    {
        private readonly IOfertasService _ofertasService;

        public OfertasController(IOfertasService ofertasService)
        {
            _ofertasService = ofertasService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ofertas = await _ofertasService.GetAll();
            return Ok(ofertas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ofertas = await _ofertasService.GetById(id);
            if (ofertas == null)
                return NotFound();

            return Ok(ofertas);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(OfertasInsertDTO ofertas)
        {
            var result = await _ofertasService.Insert(ofertas);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OfertasDescripcionDTO ofertas)
        {
            if (id != ofertas.IdOfertas)
                return NotFound();

            var result = await _ofertasService.Update(ofertas);
            if (!result)
                return BadRequest();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ofertasService.Delete(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
