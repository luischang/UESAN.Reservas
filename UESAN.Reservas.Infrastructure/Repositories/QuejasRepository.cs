using Microsoft.EntityFrameworkCore;
using System.Globalization;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Infrastructure.Data;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class QuejasRepository : IQuejasRepository
    {
        private readonly ReservasContext _dbContext;

        public QuejasRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Quejas>> GetAll()
        {
            return await _dbContext.Quejas.ToListAsync();
        }

        public async Task<Quejas> GetID(int id)
        {
            return await _dbContext
                .Quejas
                .Where(x => x.IdQuejas == id)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(Quejas quejas)
        {
            await _dbContext.Quejas.AddAsync(quejas);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(Quejas quejas)
        {
            _dbContext.Quejas.Update(quejas);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var queja = await _dbContext.Quejas.FindAsync(id);
            if (queja != null)
            {
                _dbContext.Quejas.Remove(queja);
                int rows = await _dbContext.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<Quejas>> GetByFecha(string fecha)
        {
            DateTime parsedDate;
            if (DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                var quejas = await _dbContext.Quejas
                    .Where(x => x.Fecha == parsedDate.Date)
                    .ToListAsync();

                return quejas;
            }
            else
            {
                // Manejar el caso en el que la fecha no tenga el formato esperado
                // Puede lanzar una excepción, devolver una lista vacía o realizar otra acción
                throw new ArgumentException("La fecha ingresada no tiene el formato 'Año-Mes-Dia'.");
            }
        }


    }
}
