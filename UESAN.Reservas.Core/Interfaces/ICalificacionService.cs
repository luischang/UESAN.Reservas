using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ICalificacionService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CalificacionDTO>> GetAll();
        Task<CalificacionDTO> GetById(int id);
        Task<bool> Insert(CalificacionInsertDTO calificacionInsertDTO);
        Task<bool> Update(CalificacionRecomendacionDTO calificacionRecomendacionDTO);

    }
}
