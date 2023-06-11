using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class QuejasDTO
    {
        public int IdQuejas { get; set; }

        public DateTime? Fecha { get; set; }

        public int IdUsuario { get; set; }

        public string? Descripcion { get; set; }
    }
    public class InsertQuejasDTO
    {

        public DateTime? Fecha { get; set; }

        public int IdUsuario { get; set; }

        public string? Descripcion { get; set; }
    }
}
