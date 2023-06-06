using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure.Repositories;

namespace UESAN.Reservas.Core.Services
{
    public class DetalleServiciosService : IDetalleServiciosService
    {
        private readonly IDetalleServiciosRepository _detalleServiciosRepository;

        public DetalleServiciosService(IDetalleServiciosRepository detalleServiciosRepository)
        {
            _detalleServiciosRepository = detalleServiciosRepository;
        }

        public async Task<IEnumerable<DetalleServiciosDescriptionDTO>> GetAll()
        {
            var detallesServicios = await _detalleServiciosRepository.GetAll();
            var detallesServiciosDTO = new List<DetalleServiciosDescriptionDTO>();

            foreach (var detalleServicios in detallesServicios)
            {
                var detalleServiciosDTO = new DetalleServiciosDescriptionDTO();
                detalleServiciosDTO.IdReserva = detalleServicios.IdReserva;
                detalleServiciosDTO.IdServicio = detalleServicios.IdServicio;
                detalleServiciosDTO.SubTotal = detalleServicios.SubTotal;

                detallesServiciosDTO.Add(detalleServiciosDTO);
            }
            return detallesServiciosDTO;
        }
        public async Task<DetalleServiciosDTO> GetById(int id)
        {
            var detalleServicios = await _detalleServiciosRepository.GetById(id);
            var detalleServiciosDTO = new DetalleServiciosDTO();
            detalleServiciosDTO.IdReserva = detalleServicios.IdReserva;
            detalleServiciosDTO.IdServicio = detalleServicios.IdServicio;
            detalleServiciosDTO.SubTotal = detalleServicios.SubTotal;
            return detalleServiciosDTO;
        }

        public async Task<bool> Insert(DetalleServiciosInsertDTO detalleServiciosInsertDTO)
        {
            var detalleServicios = new DetalleServicios();
            detalleServicios.SubTotal = detalleServiciosInsertDTO.SubTotal;

            var result = await _detalleServiciosRepository.Insert(detalleServicios);
            return result;
        }

        public async Task<bool> Update(DetalleServiciosDescriptionDTO detalleServiciosDescriptionDTO)
        {
            var detalleServicios = await _detalleServiciosRepository.GetById(detalleServiciosDescriptionDTO.IdReserva);
            if (detalleServicios == null)
                return false;
            //detalleServicios.IdEstadoRes = detalleServiciosDescriptionDTO.IdEstadoRes;

            var result = await _detalleServiciosRepository.Update(detalleServicios);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var detalleServicios = await _detalleServiciosRepository.GetById(id);
            if (detalleServicios == null)
                return false;

            var result = await _detalleServiciosRepository.Delete(id);
            return result;
        }
    }
}
