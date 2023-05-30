using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class TipoHabitacion
{
    public int IdTipoHabi { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Habitacion> Habitacion { get; set; } = new List<Habitacion>();
}
