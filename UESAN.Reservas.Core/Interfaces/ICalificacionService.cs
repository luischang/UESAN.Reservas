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
        CalificacionDTO GuardarCalificacion(CalificacionDTO calificacionDTO);
        CalificacionDTO GetCalificacionById(int id);
        CalificacionRecomendacionDTO Update(CalificacionRecomendacionDTO calificacionRecomendacionDTO)
    };
}
