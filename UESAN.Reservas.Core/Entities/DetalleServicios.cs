using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class DetalleServicios
{
    public int IdReserva { get; set; }

    public int? IdServicio { get; set; }

    public decimal? SubTotal { get; set; }

    public virtual ReservasOrder IdReservaNavigation { get; set; } = null!;

    public virtual Servicio? IdServicioNavigation { get; set; }
}
