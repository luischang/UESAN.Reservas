using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class IdEstadoReservaDTO
    {
        public int IdEstadoRes { get; set; }

        public string? Nombre { get; set; }

        public string? Motivo { get; set; }
    }

    public class IdEstadoReservaDescriptionDTO
    {
        public int IdEstadoRes { get; set; }

        public string? Nombre { get; set; }

        public string? Motivo { get; set; }
    }

    public class IdEstadoReservaInsertDTO
    {

        public string? Nombre { get; set; }

        public string? Motivo { get; set; }
    }

}
