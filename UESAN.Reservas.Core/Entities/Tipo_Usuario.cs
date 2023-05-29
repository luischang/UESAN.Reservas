using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.Entities
{
    public partial class Tipo_Usuario
    {
        public int Id_Tipo { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
    }
}