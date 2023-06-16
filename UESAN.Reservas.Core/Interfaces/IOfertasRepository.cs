using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IOfertasRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Ofertas>> GetAll();
        Task<Ofertas> GetById(int id);
        Task<bool> Insert(Ofertas ofertas);
        Task<bool> Update(Ofertas ofertas);
        Task<Ofertas> GetByIdOferta(int? id);
    }
}
