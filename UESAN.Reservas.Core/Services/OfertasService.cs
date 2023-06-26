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
    public class OfertasService : IOfertasService
    {
        private readonly IOfertasRepository _ofertasRepository;

        public OfertasService(IOfertasRepository ofertasRepository)
        {
            _ofertasRepository = ofertasRepository;
        }

        public async Task<IEnumerable<OfertasDescripcionDTO>> GetAll()
        {
            var ofertas = await _ofertasRepository.GetAll();
            var ofertasDTO = new List<OfertasDescripcionDTO>();

            foreach (var oferta in ofertas)
            {
                var ofertaDTO = new OfertasDescripcionDTO();
                ofertaDTO.IdOfertas = oferta.IdOfertas;
                ofertaDTO.Descripcion = oferta.Descripcion;
                ofertaDTO.Descuento = oferta.Descuento;
                ofertaDTO.FechaIni = oferta.FechaIni;
                ofertaDTO.FechaFin = oferta.FechaFin;
                ofertaDTO.Estado = oferta.Estado;

                ofertasDTO.Add(ofertaDTO);
            }
            return ofertasDTO;
        }
        public async Task<OfertasDTO> GetById(int id)
        {
            var ofertas = await _ofertasRepository.GetById(id);
            if (ofertas == null) { return null; }
            var ofertasDTO = new OfertasDTO();
            ofertasDTO.IdOfertas = ofertas.IdOfertas;
            ofertasDTO.Descripcion = ofertas.Descripcion;
            ofertasDTO.Descuento = ofertas.Descuento;
            ofertasDTO.FechaInicio = ofertas.FechaIni;
            ofertasDTO.FechaFin = ofertas.FechaFin;
            ofertasDTO.Estado = ofertas.Estado;
            return ofertasDTO;
        }

        public async Task<bool> Insert(OfertasInsertDTO ofertasInsertDTO)
        {
            var ofertas = new Ofertas();
            ofertas.Descripcion = ofertasInsertDTO.Descripcion;
            ofertas.Estado = ofertasInsertDTO.Estado;
            ofertas.FechaIni = ofertasInsertDTO.FechaIni;
            ofertas.FechaFin = ofertasInsertDTO.FechaFin;
            ofertas.Descuento = ofertasInsertDTO.Descuento;
            var result = await _ofertasRepository.Insert(ofertas);
            return result;
        }

        public async Task<bool> Update(OfertasDescripcionDTO ofertasDescripcionDTO)
        {
            var ofertas = await _ofertasRepository.GetById(ofertasDescripcionDTO.IdOfertas);
            if (ofertas == null)
                return false;
            ofertas.Descripcion = ofertasDescripcionDTO.Descripcion;

            var result = await _ofertasRepository.Update(ofertas);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var ofertas = await _ofertasRepository.GetById(id);
            if (ofertas == null)
                return false;

            var result = await _ofertasRepository.Delete(id);
            return result;
        }


    }
}
