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
        Pago GetById(int idPago);
        void Create(Pago pago);
        void Update(Pago pago);
        void Delete(Pago pago);

    }
}
