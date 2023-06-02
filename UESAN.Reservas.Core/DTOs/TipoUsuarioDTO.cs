using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class TipoUsuarioDTO
    {
        public int IdTipo { get; set; }

        public string? Descripcion { get; set; }
    }
    public class InsertTipoUsuarioDTO
    {
        public string? Descripcion { get; set; }
    }
    public class prubaTipoUsuarioDTO
    {
        public int IdTipo { get; set; }
    }
}
