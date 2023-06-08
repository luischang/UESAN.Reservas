using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class DetalleReservas
{
    public int IdReserva { get; set; }

    public int? IdHabitacion { get; set; }

    public decimal? Subtotal { get; set; }

    public virtual Habitacion? IdHabitacionNavigation { get; set; }

    public virtual ReservasOrder IdReservaNavigation { get; set; } = null!;
}
