using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class DetalleSalaDeEventosDTO
    {
        public int IdReserva { get; set; }

        public int IdSalaEvento { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? SubTotal { get; set; }
    }

    public class DescripDetalleSalaDeEventoDTO
    {
        public int IdReserva { get; set; }

        public int IdSalaEvento { get; set; }

        public decimal? SubTotal { get; set; }
    }

    public class InsertDetalleSalaDeEventosDTO
    {
        public int IdReserva { get; set; }
        public int IdSalaEvento { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public decimal? SubTotal { get; set; }
    }
}
