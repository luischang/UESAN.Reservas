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
        Oferta GetById(int idOferta);
        void Create(Oferta oferta);
        void Update(Oferta oferta);
        void Delete(Oferta oferta);

    }
}
