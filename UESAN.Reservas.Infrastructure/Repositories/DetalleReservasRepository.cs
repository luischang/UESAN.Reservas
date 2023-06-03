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

        public IEnumerable<Core.Entities.DetalleReservas> GetDetalleReservas()
        {
            var detallereservas = _context.DetalleReservas.ToList();
            return detallereservas;
        }

        //asincrono
        /*
         public async Task<IEnumerable<Core.Entities.DetalleReservas>> GetDetalleReservas()
        {
            var detallereservas= await _context.DetalleReservas.ToListAsync();
            return detallereservas;
        }
         */

        public DetalleReservas GetDetalleReservasById(int id)
        {
            var detallereservas = _context.DetalleReservas.Where(x => x.IdReserva == id).FirstOrDefault();
            if (detallereservas == null)
            {
                throw new Exception("No se encuentra el detalle de dicha reserva");
            }
            return detallereservas;

        }
        //asincrono
        /*
          public async Task<DetalleReservas> GetDetalleReservasById(int id)
        {
            var detallereservas =await _context.DetalleReservas.Where(x => x.IdReserva == id).FirstOrDefaultAsync();
            if(detallereservas == null)
            {
                throw new Exception("No se encuentra el detalle de dicha reserva");
            }
            return detallereservas;

        }
         */

        public async Task<bool> Insert(DetalleReservas detallereservas)
        {
            await _context.DetalleReservas.AddAsync(detallereservas);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;

        }

        public async Task<bool> Update(DetalleReservas detallereservas)
        {
            _context.DetalleReservas.Update(detallereservas);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var detallereservas = await _context.DetalleReservas.FindAsync(id);
            if (detallereservas == null)
                return false;
            _context.DetalleReservas.Remove(detallereservas);
            var countRows = await _context.SaveChangesAsync();
            return countRows >= 0;

        }
    }
}
