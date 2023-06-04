using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.DTOs
{
    public class OfertaDTO
    {
        public int IdOfertas { get; set; }
        public string Descripcion { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Estado { get; set; }


        public OfertaDTO(int idOfertas, string descripcion, decimal descuento, DateTime fechaInicio, DateTime fechaFin, bool estado)
        {
            IdOfertas = idOfertas;
            Descripcion = descripcion;
            Descuento = descuento;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = estado;
        }
    }
}
