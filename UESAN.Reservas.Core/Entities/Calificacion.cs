using System;
using System.Collections.Generic;

namespace UESAN.Reservas.Core.Entities;

public partial class Calificacion
{
    public int IdCalificacion { get; set; }

    public int? IdReserva { get; set; }

    public int? NumEstrellas { get; set; }

    public string? Recomendacion { get; set; }

    public virtual ReservasOrder? IdReservaNavigation { get; set; }
}
