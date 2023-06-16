using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Core.DTOs
{
    public class ReservasOrderDTO
    {
        public int IdReserva { get; set; }

        public int? IdUsuario { get; set; }

        public DateTime? FechaIni { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? IdEstadoRes { get; set; }

        public int? CantPersonas { get; set; }

        public int? IdOfertas { get; set; }

    }
    public class ReservasOrderDescriptionDTO
    {
        public int IdReserva { get; set; }

        public int? IdUsuario { get; set; }

        public DateTime? FechaIni { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? IdEstadoRes { get; set; }

        public int? CantPersonas { get; set; }

        public int? IdOfertas { get; set; }

    }

    public class ReservasOrderInsertDTO
    {

        public DateTime? FechaIni { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? CantPersonas { get; set; }

        public int IdOfertas { get; set; }

        //public List<DetalleReservasDTO> ListDetalleReservasDTO { get; set; }
        public List<DetalleServiciosDTO> ListDetalleServiciosDTO { get; set; }

        public ReservasOrderInsertDTO()
        {
            //ListDetalleReservasDTO = new List<DetalleReservasDTO>();
            ListDetalleServiciosDTO = new List<DetalleServiciosDTO>();
        }

    }

    public class ReservasOrderInsertarDTO
    {

        public int? IdUsuario { get; set; }

        public DateTime? FechaIni { get; set; }

        public DateTime? FechaFin { get; set; }

        public int? IdEstadoRes { get; set; }

        public int? CantPersonas { get; set; }

        public int? IdOfertas { get; set; }

    }
}