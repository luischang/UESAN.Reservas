using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class IdEstadoReserva
{
    public int IdEstadoRes { get; set; }

    public string? Nombre { get; set; }

    public string? Motivo { get; set; }

    public virtual ICollection<ReservasOrder> ReservasOrder { get; set; } = new List<ReservasOrder>();
}
