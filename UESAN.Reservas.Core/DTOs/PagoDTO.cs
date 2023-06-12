using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class PagoDTO
    {
        public int IdPago { get; set; }

        public int IdReserva { get; set; }
        public int MetodoPago { get; set; }
        public decimal? MontoTotal { get; set; }
        public int Estado { get; set; }

    }

    public class PagoDescripcionDTO
    {
        public int IdPago { get; set; }
        public int IdReserva { get; set; }
        public int MetodoPago { get; set; }
        public decimal? MontoTotal { get; set; }
        public int Estado { get; set; }
    }

    public class PagoInsertDTO

    {
        public int IdReserva { get; set; }
        public int MetodoPago { get; set; }
        public decimal? MontoTotal { get; set; }
        public int Estado { get; set; }
    }
}
