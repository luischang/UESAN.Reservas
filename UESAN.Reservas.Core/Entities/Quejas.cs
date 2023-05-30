using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Quejas
{
    public int IdQuejas { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdUsuario { get; set; }

    public string? Descripcion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
