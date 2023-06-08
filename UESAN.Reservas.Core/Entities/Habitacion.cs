using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Habitacion
{
    public int IdHabitacion { get; set; }

    public string? Descripcion { get; set; }

    public int? Capacidad { get; set; }

    public bool? Estado { get; set; }

    public int? IdTipoHabi { get; set; }

    public decimal? Precio { get; set; }

    public int? CantCamas { get; set; }

    public virtual ICollection<DetalleReservas> DetalleReservas { get; set; } = new List<DetalleReservas>();

    public virtual TipoHabitacion? IdTipoHabiNavigation { get; set; }
}
