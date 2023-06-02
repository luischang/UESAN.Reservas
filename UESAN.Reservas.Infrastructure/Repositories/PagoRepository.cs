using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly YourDbContext dbContext;

        public PagoRepository(YourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Pago GetById(int idPago)
        {
            return dbContext.Pagos.FirstOrDefault(p => p.IdPago == idPago);
        }

        public void Create(Pago pago)
        {
            dbContext.Pagos.Add(pago);
            dbContext.SaveChanges();
        }

        public void Update(Pago pago)
        {
            dbContext.Pagos.Update(pago);
            dbContext.SaveChanges();
        }

        public void Delete(Pago pago)
        {
            dbContext.Pagos.Remove(pago);
            dbContext.SaveChanges();
        }

    }
}
