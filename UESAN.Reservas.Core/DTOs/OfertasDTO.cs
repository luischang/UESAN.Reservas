using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.DTOs
{
    public class OfertasDTO
    {
        public int IdOfertas { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public decimal Descuento { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }
    }

    public class OfertasDescripcionDTO
    {
        public int IdOfertas { get; set; }
        public string Descripcion { get; set; }
    }

    public class OfertasInsertDTO
    {
        public string Descripcion { get; set; }
        public decimal? Descuento { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool Estado { get; set; }
    }
}
