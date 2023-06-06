using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure.Data;
using UESAN.Reservas.Infrastructure.Repositories;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class ReservasOrderRepository : IReservasOrderRepository
    {
        private readonly ReservasContext _dbContext;

        public ReservasOrderRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReservasOrder>> GetAll()
        {
            return await _dbContext
                         .ReservasOrder
                         .Where(x => x.IdEstadoRes != 3)
                         .ToListAsync();
        }

        public async Task<ReservasOrder> GetById(int id)
        {
            return await _dbContext
                        .ReservasOrder
                        .Where(x => x.IdReserva == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(ReservasOrder reservasOrder)
        {
            await _dbContext.ReservasOrder.AddAsync(reservasOrder);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(ReservasOrder reservasOrder)
        {
            _dbContext.ReservasOrder.Update(reservasOrder);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findReservasOrder = await _dbContext
                                .ReservasOrder
                                .Where(x => x.IdReserva == id)
                                .FirstOrDefaultAsync();
            if (findReservasOrder == null)
                return false;

            findReservasOrder.IdEstadoRes = 3;
            _dbContext.ReservasOrder.Update(findReservasOrder);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
