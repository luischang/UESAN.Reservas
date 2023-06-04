using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IOfertaRepository
    {
        Ofertas GetById(int idOferta);
        void Create(Ofertas oferta);
        void Update(Ofertas oferta);
        void Delete(Ofertas oferta);

    }
}
