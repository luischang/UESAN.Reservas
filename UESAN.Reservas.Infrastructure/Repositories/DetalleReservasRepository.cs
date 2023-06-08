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
    public class DetalleReservasRepository : IDetalleReservasRepository
    {
        private readonly ReservasContext _context;

        public DetalleReservasRepository(ReservasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetalleReservas>> GetDetalleReservas()
        {
            return await _context.DetalleReservas
               .Where(x => x.IdReserva > 0)
               .Include(z => z.IdReservaNavigation)
               .Include(i => i.IdHabitacionNavigation)
               .ToListAsync();

        }


        public async Task<DetalleReservas> GetDetalleReservasById(int id)
        {
            return await _context.DetalleReservas.Where(x => x.IdReserva == id)
                .Include(z => z.IdReservaNavigation)
                .Include(i => i.IdHabitacionNavigation)
                .FirstOrDefaultAsync();

        }


        public async Task<bool> Insert(DetalleReservas detallereservas)
        {
            await _context.DetalleReservas.AddAsync(detallereservas);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;

        }



        /* public async Task<bool> Delete(int id)
         {
             var detallereservas = await _context.DetalleReservas.FindAsync(id);
             if (detallereservas == null)
                 return false;
             _context.DetalleReservas.Remove(detallereservas);
             var countRows = await _context.SaveChangesAsync();
             return countRows >= 0;

         }*/
    }
}
