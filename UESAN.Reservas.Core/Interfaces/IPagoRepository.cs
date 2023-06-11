using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IPagoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Pago>> GetAll();
        Task<Pago> GetById(int id);
        Task<bool> Insert(Pago pago);
        Task<bool> Update(Pago pago);

    }
}
