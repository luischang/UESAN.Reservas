using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Ofertas
{
    public int IdOfertas { get; set; }

    public string Descripcion { get; set; }

    public decimal Descuento { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<ReservasOrder> ReservasOrder { get; set; } = new List<ReservasOrder>();
}
