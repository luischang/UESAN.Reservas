using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.DTOs
{
    public class ServicioDTO
    {
        public int IdServicio { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        public decimal? Precio { get; set; }

    }
    public class ServicioDescriptionDTO
    {
        public int IdServicio { get; set; }

        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

        public decimal? Precio { get; set; }

    }

    public class ServicioInsertDTO
    {

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public decimal? Precio { get; set; }

    }
}