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
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly ReservasContext _dbContext;

        public CalificacionRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Calificacion>> GetAll()
        {
            return await _dbContext
                         .Calificacion
                         .ToListAsync();
        }

        public async Task<Calificacion> GetById(int id)
        {
            return await _dbContext
                        .Calificacion
                        .Where(x => x.IdCalificacion == id)
                        .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Calificacion calificacion)
        {
            await _dbContext.Calificacion.AddAsync(calificacion);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Calificacion calificacion)
        {
            _dbContext.Calificacion.Update(calificacion);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findCalificacion = await _dbContext
                                .Calificacion
                                .Where(x => x.IdCalificacion == id)
                                .FirstOrDefaultAsync();
            if (findCalificacion == null)
                return false;

            findCalificacion.NumEstrellas = 0;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
