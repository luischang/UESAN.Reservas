using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class UsuarioDTO
        {
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public int? IdTipo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public bool? Estado { get; set; }
        public int? Puntos { get; set; }
        }

    public class UsuarioAuthResponseDTO
        {
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public int? IdTipo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public bool? Estado { get; set; }
        public int? Puntos { get; set; }

    }

    public class UsuarioAuthRequestDTO
        {
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public int? IdTipo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? Puntos { get; set; }
    }

    public class UsuarioAuthenticationDTO
        {
            public string? Email { get; set; }
            public string? Contraseña { get; set; }
        }
}
