using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdReserva { get; set; }

    public int? MetodoPago { get; set; }

    public decimal? MontoTotal { get; set; }

    public int? Estado { get; set; }

    public virtual ReservasOrder? IdReservaNavigation { get; set; }
}
