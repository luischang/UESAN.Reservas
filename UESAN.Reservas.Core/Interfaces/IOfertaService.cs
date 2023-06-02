using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IOfertaService
    {
        OfertaDTO ObtenerOferta(int idOferta);
        OfertaDTO GuardarOferta(OfertaDTO ofertaDTO);
        void ActualizarOferta(OfertaDTO ofertaDTO);
        void EliminarOferta(int idOferta);

    }
}
