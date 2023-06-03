using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Core.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IOfertaRepository ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            this.ofertaRepository = ofertaRepository;
        }

        public OfertaDTO ObtenerOferta(int idOferta)
        {
            var oferta = ofertaRepository.GetById(idOferta);
            return MapOfertaToDTO(oferta);
        }

        public OfertaDTO GuardarOferta(OfertaDTO ofertaDTO)
        {
            var oferta = MapDTOToOferta(ofertaDTO);
            ofertaRepository.Create(oferta);
            return MapOfertaToDTO(oferta);
        }

        public void ActualizarOferta(OfertaDTO ofertaDTO)
        {
            var oferta = MapDTOToOferta(ofertaDTO);
            ofertaRepository.Update(oferta);
        }

        public void EliminarOferta(int idOferta)
        {
            var oferta = ofertaRepository.GetById(idOferta);
            if (oferta != null)
                ofertaRepository.Delete(oferta);
        }


        private OfertaDTO MapOfertaToDTO(Oferta oferta)
        {
            return new OfertaDTO
            {
                IdOferta = oferta.IdOferta,
                Descripcion = oferta.Descripcion,
                Descuento = oferta.Descuento,
                FechaInicio = oferta.FechaInicio,
                FechaFin = oferta.FechaFin,
                Estado = oferta.Estado
            };
        }

        private Oferta MapDTOToOferta(OfertaDTO ofertaDTO)
        {
            return new Oferta
            {
                IdOferta = ofertaDTO.IdOferta,
                Descripcion = ofertaDTO.Descripcion,
                Descuento = ofertaDTO.Descuento,
                FechaInicio = ofertaDTO.FechaInicio,
                FechaFin = ofertaDTO.FechaFin,
                Estado = ofertaDTO.Estado
            };
        }
    }
}
