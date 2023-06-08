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
    public class IdEstadoReservaService : IIdEstadoReservaService
    {
        private readonly IIdEstadoReservaRepository _idEstadoReservaRepository;

        public IdEstadoReservaService(IIdEstadoReservaRepository idEstadoReservaRepository)
        {
            _idEstadoReservaRepository = idEstadoReservaRepository;
        }

        public async Task<IEnumerable<IdEstadoReservaDescriptionDTO>> GetAll()
        {
            var idEstadoReservas = await _idEstadoReservaRepository.GetAll();
            var idEstadoReservasDTO = new List<IdEstadoReservaDescriptionDTO>();

            foreach (var idEstadoReserva in idEstadoReservas)
            {
                var idEstadoReservaDTO = new IdEstadoReservaDescriptionDTO();
                idEstadoReservaDTO.IdEstadoRes = idEstadoReserva.IdEstadoRes;
                idEstadoReservaDTO.Nombre = idEstadoReserva.Nombre;
                idEstadoReservaDTO.Motivo = idEstadoReserva.Motivo;

                idEstadoReservasDTO.Add(idEstadoReservaDTO);
            }
            return idEstadoReservasDTO;
        }
        public async Task<IdEstadoReservaDTO> GetById(int id)
        {
            var idEstadoReserva = await _idEstadoReservaRepository.GetById(id);
            var idEstadoReservaDTO = new IdEstadoReservaDTO();
            idEstadoReservaDTO.IdEstadoRes = idEstadoReserva.IdEstadoRes;
            idEstadoReservaDTO.Nombre = idEstadoReserva.Nombre;
            idEstadoReservaDTO.Motivo = idEstadoReserva.Motivo;
            return idEstadoReservaDTO;
        }

        public async Task<bool> Insert(IdEstadoReservaInsertDTO idEstadoReservaInsertDTO)
        {
            var idEstadoReserva = new IdEstadoReserva();
            idEstadoReserva.Nombre = idEstadoReservaInsertDTO.Nombre;
            idEstadoReserva.Motivo = idEstadoReservaInsertDTO.Motivo;

            var result = await _idEstadoReservaRepository.Insert(idEstadoReserva);
            return result;
        }

        public async Task<bool> Update(IdEstadoReservaDescriptionDTO idEstadoReservaDescriptionDTO)
        {
            var idEstadoReserva = await _idEstadoReservaRepository.GetById(idEstadoReservaDescriptionDTO.IdEstadoRes);
            if (idEstadoReserva == null)
                return false;
            idEstadoReserva.IdEstadoRes = idEstadoReservaDescriptionDTO.IdEstadoRes;

            var result = await _idEstadoReservaRepository.Update(idEstadoReserva);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var idEstadoReserva = await _idEstadoReservaRepository.GetById(id);
            if (idEstadoReserva == null)
                return false;

            var result = await _idEstadoReservaRepository.Delete(id);
            return result;
        }
    }
}
