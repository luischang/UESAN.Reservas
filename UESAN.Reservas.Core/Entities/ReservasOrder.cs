using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class ReservasOrder
{
    public int IdReserva { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaIni { get; set; }

    public DateTime? FechaFin { get; set; }

    public int? IdEstadoRes { get; set; }

    public int? CantPersonas { get; set; }

    public int? IdOfertas { get; set; }

    public virtual ICollection<Calificacion> Calificacion { get; set; } = new List<Calificacion>();

    public virtual DetalleReservas? DetalleReservas { get; set; }

    public virtual DetalleServicios? DetalleServicios { get; set; }

    public virtual IdEstadoReserva? IdEstadoResNavigation { get; set; }

    public virtual Ofertas? IdOfertasNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
