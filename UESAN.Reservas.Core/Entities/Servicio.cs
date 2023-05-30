using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<DetalleServicios> DetalleServicios { get; set; } = new List<DetalleServicios>();
}
