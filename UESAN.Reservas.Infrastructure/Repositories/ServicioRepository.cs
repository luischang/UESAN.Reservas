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
    public class ServicioRepository : IServicioRepository
    {
        private readonly ReservasContext _dbContext;

        public ServicioRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Servicio>> GetAll()
        {
            return await _dbContext
                         .Servicio
                         .Where(x => x.Estado == true)
                         .ToListAsync();
        }

        public async Task<Servicio> GetById(int id)
        {
            return await _dbContext
                        .Servicio
                        .Where(x => x.IdServicio == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Servicio servicio)
        {
            await _dbContext.Servicio.AddAsync(servicio);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Servicio servicio)
        {
            _dbContext.Servicio.Update(servicio);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findServicio = await _dbContext
                                .Servicio
                                .Where(x => x.IdServicio == id)
                                .FirstOrDefaultAsync();
            if (findServicio == null)
                return false;

            findServicio.Estado = false;
            _dbContext.Servicio.Update(findServicio);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
