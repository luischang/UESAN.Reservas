using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Core.Services
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly ITipoHabitacionRepository _tipoHabitacionRespository;


        public TipoHabitacionService(ITipoHabitacionRepository tipoHabitacionRepository)
        {
            _tipoHabitacionRespository = tipoHabitacionRepository;
        }

        public async Task<IEnumerable<TipoHabitacionDTO>> GetAll()
        {
            var TiposH = await _tipoHabitacionRespository.GetAll();

            var th = TiposH.Select(e => new TipoHabitacionDTO
            {
                Id_TipoHabi = e.IdTipoHabi,
                Descripcion = e.Descripcion

            });
            return th;
        }

        public async Task<TipoHabitacionDTO> GetById(int id)
        {
            var th = await _tipoHabitacionRespository.GetTipoHabitacionById(id);
            if (th == null)
                return null;
            var thDTO = new TipoHabitacionDTO()
            {
                Id_TipoHabi = th.IdTipoHabi,
                Descripcion = th.Descripcion,


            };
            return thDTO;
        }
    }
}
