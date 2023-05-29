using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.Entities
{
    public partial class Quejas
    {
        public int Id_Quejas { get; set; }
        public DateTime? Fecha { get; set; }
        public int Id_Usuario { get; set; }
        public string? Descripcion { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}