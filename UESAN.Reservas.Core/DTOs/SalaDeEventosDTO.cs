using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.DTOs
{
    public class SalaDeEventosDTO
    {
        public int IdSalaEvento { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int? IdTipoEvento { get; set; }

        public decimal? Precio { get; set; }
    }

    public class InsertSalaDeEventosDTO
    {

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        public int? IdTipoEvento { get; set; }

        public decimal? Precio { get; set; }
    }

}
