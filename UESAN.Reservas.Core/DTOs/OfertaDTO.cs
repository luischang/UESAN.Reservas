using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class OfertaDTO
    {
        public int IdOferta { get; set; }
        public string Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }

    }
}
