using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class TipoUsuario
{
    public int IdTipo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
