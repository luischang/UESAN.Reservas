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
    public class OfertasRepository : IOfertasRepository    {
        private readonly ReservasContext _dbContext;

        public OfertasRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ofertas>> GetAll()
        {
            return await _dbContext
                         .Ofertas
                         .Where(x => x.Estado == true)
                         .ToListAsync();
        }

        public async Task<Ofertas> GetById(int id)
        {
            return await _dbContext
                        .Ofertas
                        .Where(x => x.IdOfertas == id)
                        .FirstOrDefaultAsync();
        }
        public async Task<Ofertas> GetByIdOferta(int? id)
        {
            return await _dbContext
                        .Ofertas
                        .Where(x => x.IdOfertas == id)
                        .FirstOrDefaultAsync();
        }



        public async Task<bool> Insert(Ofertas ofertas)
        {
            await _dbContext.Ofertas.AddAsync(ofertas);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Ofertas ofertas)
        {
            _dbContext.Ofertas.Update(ofertas);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var findOfertas = await _dbContext
                                .Ofertas
                                .Where(x => x.IdOfertas == id)
                                .FirstOrDefaultAsync();
            if (findOfertas == null)
                return false;

            findOfertas.Estado = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public Task<Ofertas> GetById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
