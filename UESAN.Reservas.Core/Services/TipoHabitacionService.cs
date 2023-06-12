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
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly ITipoHabitacionRepository _tipoHabitacionRepository;


        public TipoHabitacionService(ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _tipoHabitacionRepository = tipoHabitacionRepository;
        }

        public async Task<IEnumerable<TipoHabitacionDTO>> GetAll()
        {
            var TiposH = await _tipoHabitacionRepository.GetAll();

            var th = TiposH.Select(e => new TipoHabitacionDTO
            {
                Id_TipoHabi = e.IdTipoHabi,
                Descripcion = e.Descripcion

            });
            return th;
        }

        public async Task<TipoHabitacionDTO> GetById(int id)
        {
            var th = await _tipoHabitacionRepository.GetTipoHabitacionById(id);
            if (th == null)
                return null;
            var thDTO = new TipoHabitacionDTO()
            {
                Id_TipoHabi = th.IdTipoHabi,
                Descripcion = th.Descripcion,


            };
            return thDTO;
        }

        public async Task<bool> Insert(TipoHabitacionInsertDTO tipoHabitacionInsertDTO)
        {
            var tipohabitacion = new TipoHabitacion();
            tipohabitacion.Descripcion = tipoHabitacionInsertDTO.Descripcion;

            var result = await _tipoHabitacionRepository.Insert(tipohabitacion);
            return result;
        }

        public async Task<bool> Update(TipoHabitacionDescriptionDTO tipoHabitacionDescriptionDTO)
        {
            var tipohabitacion = await _tipoHabitacionRepository.GetTipoHabitacionById(tipoHabitacionDescriptionDTO.Id_TipoHabi);
            if (tipohabitacion == null)
                return false;
            tipohabitacion.Descripcion = tipohabitacion.Descripcion;

            var result = await _tipoHabitacionRepository.Update(tipohabitacion);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var tipoHabitacion = await _tipoHabitacionRepository.GetTipoHabitacionById(id);
            if (tipoHabitacion == null)
                return false;
            var result = await _tipoHabitacionRepository.Delete(id);
            return result;
        }
    }
}
