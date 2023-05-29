using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.Entities
{
    public partial class Usuario
    {
        public int Id_Usuario { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public int Id_Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public Byte[]? Estado { get; set; }
        public int Puntos { get; set; }

        public virtual Tipo_Usuario? TipoUsuario { get; set; }

        public virtual ICollection<Quejas> Quejas { get; set; } = new List<Quejas>();

    }
}