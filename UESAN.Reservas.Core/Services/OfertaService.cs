using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Services
{
    public class OfertaService 
    {
        private readonly IOfertaRepository ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            this.ofertaRepository = ofertaRepository;
        }

       /* public OfertaDTO ObtenerOferta(int idOferta)
        {
            var oferta = ofertaRepository.GetById(idOferta);
            if (oferta == null)
                return null;

            return new OfertaDTO(
                oferta.IdOfertas,
                oferta.Descripcion,
                oferta.Descuento,
                oferta.FechaIni,
                oferta.FechaFin,
                oferta.Estado);
        }*/

       /* public OfertaDTO GuardarOferta(OfertaDTO ofertaDTO)
        {
            var oferta = new Ofertas
            {
                IdOfertas = ofertaDTO.IdOfertas,
                Descripcion = ofertaDTO.Descripcion,
                Descuento = ofertaDTO.Descuento,
                FechaInicio = ofertaDTO.FechaInicio,
                FechaFin = ofertaDTO.FechaFin,
                Estado = ofertaDTO.Estado
            };

            ofertaRepository.Create(oferta);

            return new OfertaDTO(
                oferta.IdOfertas,
                oferta.Descripcion,
                oferta.Descuento,
                oferta.FechaInicio,
                oferta.FechaFin,
                oferta.Estado);
        }

        public void ActualizarOferta(OfertaDTO ofertaDTO)
        {
            var oferta = new Ofertas
            {
                IdOfertas = ofertaDTO.IdOfertas,
                Descripcion = ofertaDTO.Descripcion,
                Descuento = ofertaDTO.Descuento,
                FechaInicio = ofertaDTO.FechaInicio,
                FechaFin = ofertaDTO.FechaFin,
                Estado = ofertaDTO.Estado
            };

            ofertaRepository.Update(oferta);
        }

        public void EliminarOferta(int idOferta)
        {
            var oferta = ofertaRepository.GetById(idOferta);
            if (oferta != null)
                ofertaRepository.Delete(oferta);
        }*/
    }
}
