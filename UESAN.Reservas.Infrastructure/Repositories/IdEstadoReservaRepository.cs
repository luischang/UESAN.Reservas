using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Infrastructure.Data;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class IdEstadoReservaRepository : IIdEstadoReservaRepository
    {
        private readonly ReservasContext _dbContext;

        public IdEstadoReservaRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IdEstadoReserva>> GetAll()
        {
            return await _dbContext
                         .IdEstadoReserva
                         //.Where(x => x.IdEstadoRes == true)
                         .ToListAsync();
        }

        public async Task<IdEstadoReserva> GetById(int id)
        {
            return await _dbContext
                        .IdEstadoReserva
                        .Where(x => x.IdEstadoRes == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(IdEstadoReserva idEstadoReserva)
        {
            await _dbContext.IdEstadoReserva.AddAsync(idEstadoReserva);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(IdEstadoReserva idEstadoReserva)
        {
            _dbContext.IdEstadoReserva.Update(idEstadoReserva);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findIdEstadoReserva = await _dbContext
                                .IdEstadoReserva
                                .Where(x => x.IdEstadoRes == id)
                                .FirstOrDefaultAsync();
            if (findIdEstadoReserva == null)
                return false;

            //findIdEstadoReserva.IdEstadoRes = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
