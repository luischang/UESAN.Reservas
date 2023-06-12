using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class DetalleReservasDTO
    {
        public int IdReserva { get; set; }

        public int? IdHabitacion { get; set; }

        public decimal? Subtotal { get; set; }
    }

    //public class DetalleReservaInsertDTO {

    //    public HabitacionDetalleReservaInsertDTO HabitacionDetalle { get; set; }


    //}
    public class DetalleReservaDescriptionDTO
    {
        public int IdReserva { get; set; }

        public int? IdHabitacion { get; set; }

        public decimal? SubTotal { get; set; }
    }

    public class DetalleReservasInsertDTO
    {
        public int IdReserva { get; set; }

        public int? IdHabitacion { get; set; }

    }


}
