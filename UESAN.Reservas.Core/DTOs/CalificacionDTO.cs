using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class CalificacionDTO
    {
        public int IdCalificacion { get; set; }
        public int IdReserva { get; set; }
        public int NumEstrellas { get; set; }
        public string? Recomendacion { get; set; }


    }

    public class CalificacionRecomendacionDTO
    {
        public int IdCalificacion { get; set; }
        public string? Recomendacion { get; set; }
    }

    public class CalificacionInsertDTO
    {
        public int IdReserva { get; set; }
        public string? Recomendacion { get; set; }
        public int NumEstrellas { get; set; }
    }
}
