using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class TipoSalaEvento
{
    public int IdTipoEvento { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<SalaDeEventos> SalaDeEventos { get; set; } = new List<SalaDeEventos>();
}
