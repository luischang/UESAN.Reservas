using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IPagoService
    {
        PagoDTO ObtenerPago(int idPago);
        PagoDTO GuardarPago(PagoDTO pagoDTO);
        void ActualizarPago(PagoDTO pagoDTO);
        void EliminarPago(int idPago);

    }
}
