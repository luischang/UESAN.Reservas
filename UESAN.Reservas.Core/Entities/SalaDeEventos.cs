using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class SalaDeEventos
{
    public int IdSalaEvento { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public int? IdTipoEvento { get; set; }

    public decimal? Precio { get; set; }

    public virtual TipoSalaEvento? IdTipoEventoNavigation { get; set; }
}
