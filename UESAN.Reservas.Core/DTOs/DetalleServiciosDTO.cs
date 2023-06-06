using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class DetalleServiciosDTO
    {
        public int IdReserva { get; set; }

        public int? IdServicio { get; set; }

        public decimal? SubTotal { get; set; }
    }

    public class DetalleServiciosDescriptionDTO
    {
        public int IdReserva { get; set; }

        public int? IdServicio { get; set; }

        public decimal? SubTotal { get; set; }
    }

    public class DetalleServiciosInsertDTO
    {
        public decimal? SubTotal { get; set; }
    }

}