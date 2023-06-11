using Microsoft.EntityFrameworkCore;
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
        private readonly ReservasContext _dbContext;

        public PagoRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Pago>> GetAll()
        {
            return await _dbContext
                         .Pago
                         .ToListAsync();
        }

        public async Task<Pago> GetById(int id)
        {
            return await _dbContext
                        .Pago
                        .Where(x => x.IdPago == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Pago pago)
        {
            await _dbContext.Pago.AddAsync(pago);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Pago pago)
        {
            _dbContext.Pago.Update(pago);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findPago = await _dbContext
                                .Pago
                                .Where(x => x.IdPago == id)
                                .FirstOrDefaultAsync();
            if (findPago == null)
                return false;

            findPago.Estado = 0;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
