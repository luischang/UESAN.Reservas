using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class DetalleSalaEventos
{
    public int IdReserva { get; set; }

    public int IdSalaEvento { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual ReservasOrder IdReservaNavigation { get; set; } = null!;

    public virtual SalaDeEventos IdSalaEventoNavigation { get; set; } = null!;
}
