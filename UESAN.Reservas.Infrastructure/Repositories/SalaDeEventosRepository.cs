using Microsoft.EntityFrameworkCore;
using System.Globalization;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Infrastructure.Data;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class SalaDeEventosRepository : ISalaDeEventosRepository
    {
        private readonly ReservasContext _reservasContext;

        public SalaDeEventosRepository(ReservasContext reservasContext)
        {
            _reservasContext = reservasContext;
        }

        public async Task<IEnumerable<SalaDeEventos>> GetAll()
        {
            return await _reservasContext.SalaDeEventos.ToListAsync();
        }

        public async Task<SalaDeEventos> GetId(int id)
        {
            return await _reservasContext
                .SalaDeEventos
                .Where(x => x.IdSalaEvento == id)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(SalaDeEventos salaDeEventos)
        {
            await _reservasContext.SalaDeEventos.AddAsync(salaDeEventos);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(SalaDeEventos salaDeEventos)
        {
            _reservasContext.SalaDeEventos.Update(salaDeEventos);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(SalaDeEventos salaDeEventos)
        {
            _reservasContext.SalaDeEventos.Update(salaDeEventos);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
