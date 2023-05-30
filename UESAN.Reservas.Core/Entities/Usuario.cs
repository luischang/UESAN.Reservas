using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Usuario
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

    public virtual TipoUsuario? IdTipoNavigation { get; set; }

    public virtual ICollection<Quejas> Quejas { get; set; } = new List<Quejas>();

    public virtual ICollection<ReservasOrder> ReservasOrder { get; set; } = new List<ReservasOrder>();
}
