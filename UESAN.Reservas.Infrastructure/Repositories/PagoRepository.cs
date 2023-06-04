using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure.Data;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly ReservasContext dbContext;

        public PagoRepository(ReservasContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Pago GetById(int idPago)
        {
            return dbContext.Pago.FirstOrDefault(p => p.IdPago == idPago);
        }

        public void Create(Pago pago)
        {
            dbContext.Pago.Add(pago);
            dbContext.SaveChanges();
        }

        public void Update(Pago pago)
        {
            dbContext.Pago.Update(pago);
            dbContext.SaveChanges();
        }

        public void Delete(Pago pago)
        {
            dbContext.Pago.Remove(pago);
            dbContext.SaveChanges();
        }

    }
}
