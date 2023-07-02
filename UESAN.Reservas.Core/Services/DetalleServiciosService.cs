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
    public class DetalleServiciosService : IDetalleServiciosService
    {
        private readonly IDetalleServiciosRepository _detalleServiciosRepository;
        private readonly IServicioRepository _servicioRepository;

        public DetalleServiciosService(IDetalleServiciosRepository detalleServiciosRepository, IServicioRepository servicioRepository)
        {
            _detalleServiciosRepository = detalleServiciosRepository;
            _servicioRepository = servicioRepository;
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
        public async Task<IEnumerable<DetalleServiciosDescriptionDTO>> GetById(int id)
        {
            var detallesServicios = await _detalleServiciosRepository.GetById(id);
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

        public async Task<bool> Insert(DetalleServiciosInsertDTO detalleServiciosInsertDTO)
        {
            var precio = await _servicioRepository.GetById((int)detalleServiciosInsertDTO.IdServicio);
            var detalleServicios = new DetalleServicios();
            detalleServicios.IdReserva = detalleServiciosInsertDTO.IdReserva;
            detalleServicios.IdServicio = detalleServiciosInsertDTO.IdServicio;
            detalleServicios.SubTotal = precio.Precio;

            var result = await _detalleServiciosRepository.Insert(detalleServicios);
            return result;
        }

        public async Task<bool> Update(DetalleServiciosDescriptionDTO detalleServiciosDescriptionDTO)
        {
            var detalleServicios = await _detalleServiciosRepository.GetByIdupdate(detalleServiciosDescriptionDTO.IdReserva);
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
