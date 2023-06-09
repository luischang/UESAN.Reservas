using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class HabitacionDTO
    {
        public int Id_Habitacion { get; set; }
        public String? Descripcion { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int Id_TipoHabi { get; set; }
        public decimal Precio { get; set; }
        public int Cant_Camas { get; set; }
    }
    public class HabitacionDescriptionDTO
    {
        public int Id_Habitacion { get; set; }
        public String? Descripcion { get; set; }

    }

    public class HabitacionInsertDTO
    {
        public String? Descripcion { get; set; }
        public int? Capacidad { get; set; }
        //public decimal? Precio { get; set; }
        public int? Cant_Camas { get; set; }
        public TipoHabitacionDescriptionDTO TipoHabitacion { get; set; }
    }
    public class HabitacionUpdateDTO
    {
        public int Id_Habitacion { get; set; }
        public String? Descripcion { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int Id_TipoHabi { get; set; }
        //public decimal Precio { get; set; }
        public int Cant_Camas { get; set; }
    }

    public class HabitacionTipoHabitacionDTO
    {
        public int Id_Habitacion { get; set; }
        public String? Descripcion { get; set; }
        public int? Capacidad { get; set; }
        public bool? Estado { get; set; }
        public decimal? Precio { get; set; }
        public int? Cant_Camas { get; set; }
        public TipoHabitacionDescriptionDTO TipoHabitacion { get; set; }
    }

    /*public class HabitacionDetalleReservaInsertDTO
    {
        public int Id_Habitacion { get; set; }
        public decimal? Precio { get; set; }

    }*/
    
    public class HabitacionDetalleReservaInsertDTO
    {
        public int Id_Habitacion { get; set; }
        public String? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public TipoHabitacionDescriptionDTO TipoHabitacion { get; set; }
    }
   

}