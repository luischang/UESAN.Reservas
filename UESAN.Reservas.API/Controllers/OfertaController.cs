using Microsoft.AspNetCore.Mvc;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaService ofertaService;

        public OfertaController(IOfertaService ofertaService)
        {
            this.ofertaService = ofertaService;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerOferta(int id)
        {
            var oferta = ofertaService.ObtenerOferta(id);

            if (oferta == null)
                return NotFound();

            return Ok(oferta);
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarOferta(int id)
        {
            ofertaService.EliminarOferta(id);
            return NoContent();
        }
    }
}
