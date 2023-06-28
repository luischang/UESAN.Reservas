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
                         .Where(x => x.IdEstadoRes != 3 && x.IdReserva != null)
                         .ToListAsync();
        }

        public async Task<ReservasOrder> GetById(int id)
        {
            return await _dbContext
                .ReservasOrder
                .FirstOrDefaultAsync(x => x.IdReserva == id && x.IdReserva != null);
        }


        public async Task<int> Insert(ReservasOrder reservasOrder)
        {
            await _dbContext.ReservasOrder.AddAsync(reservasOrder);
            await _dbContext.SaveChangesAsync();
            // Aquí se accede al IdReserva generado después de guardar los cambios en la base de datos
            var entry = _dbContext.Entry(reservasOrder);
            var idReserva = (int)entry.Property("IdReserva").CurrentValue;


            return idReserva;
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
