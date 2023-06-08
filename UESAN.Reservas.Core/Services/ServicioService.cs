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
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioService(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ServicioDescriptionDTO>> GetAll()
        {
            var servicios = await _servicioRepository.GetAll();
            var serviciosDTO = new List<ServicioDescriptionDTO>();

            foreach (var servicio in servicios)
            {
                var servicioDTO = new ServicioDescriptionDTO();
                servicioDTO.IdServicio = servicio.IdServicio;
                servicioDTO.Descripcion = servicio.Descripcion;
                servicioDTO.Estado = servicio.Estado;
                servicioDTO.Precio = servicio.Precio;

                serviciosDTO.Add(servicioDTO);
            }
            return serviciosDTO;
        }
        public async Task<ServicioDTO> GetById(int id)
        {
            var servicio = await _servicioRepository.GetById(id);
            var servicioDTO = new ServicioDTO();
            servicioDTO.IdServicio = servicio.IdServicio;
            servicioDTO.Descripcion = servicio.Descripcion;
            servicioDTO.Estado = servicio.Estado;
            servicioDTO.Precio = servicio.Precio;
            return servicioDTO;
        }

        public async Task<bool> Insert(ServicioInsertDTO servicioInsertDTO)
        {
            var servicio = new Servicio();
            servicio.Descripcion = servicioInsertDTO.Descripcion;
            servicio.Estado = servicioInsertDTO.Estado;
            servicio.Precio = servicioInsertDTO.Precio;

            var result = await _servicioRepository.Insert(servicio);
            return result;
        }

        public async Task<bool> Update(ServicioDescriptionDTO servicioDescriptionDTO)
        {
            var servicio = await _servicioRepository.GetById(servicioDescriptionDTO.IdServicio);
            if (servicio == null)
                return false;
            servicio.Descripcion = servicioDescriptionDTO.Descripcion;

            var result = await _servicioRepository.Update(servicio);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var servicio = await _servicioRepository.GetById(id);
            if (servicio == null)
                return false;

            var result = await _servicioRepository.Delete(id);
            return result;
        }
    }
}
