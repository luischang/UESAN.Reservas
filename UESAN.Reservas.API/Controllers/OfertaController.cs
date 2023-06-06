﻿using Microsoft.AspNetCore.Mvc;
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

<<<<<<< HEAD
=======
        [HttpPost]
        public IActionResult GuardarOferta([FromBody] OfertaDTO ofertaDTO)
        {
            var nuevaOferta = ofertaService.GuardarOferta(ofertaDTO);
            return CreatedAtAction(nameof(ObtenerOferta), new { id = nuevaOferta.IdOfertas }, nuevaOferta);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarOferta(int id, [FromBody] OfertaDTO ofertaDTO)
        {
            if (id != ofertaDTO.IdOfertas)
                return BadRequest();

            ofertaService.ActualizarOferta(ofertaDTO);

            return NoContent();
        }

>>>>>>> Ultimos Cambios
        [HttpDelete("{id}")]
        public IActionResult EliminarOferta(int id)
        {
            ofertaService.EliminarOferta(id);
            return NoContent();
        }
    }
}
