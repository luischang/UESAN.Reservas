using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class TipoHabitacionDTO
    {
        public int Id_TipoHabi { get; set; }
        public string Descripcion { get; set; }
    }

    public class TipoHabitacionInsertDTO
    {
        public string Descripcion { get; set; }
    }

}
