using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
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


        public async Task<DetalleReservas> GetDetalleReservasById(int e)
        {
            return await _context.DetalleReservas.Where(x => x.IdReserva == e)
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
        public async Task<bool> Update(DetalleReservas detalleReservas)
        {
            _context.DetalleReservas.Update(detalleReservas);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
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



        //posible metodo a utilizar
        public async Task<IEnumerable<DetalleReservas>> GetId(int id)
        {
            var detallereservas = await _context.DetalleReservas.Where(x => x.IdReserva == id).ToListAsync();

            return detallereservas;

        }

        public async Task<bool> getIds(DetalleReservaDescriptionDTO detalleReservaDescriptionDTO)
        {
            var detalle= await _context.DetalleReservas.Where(x=>x.IdReserva==detalleReservaDescriptionDTO.IdReserva && x.IdHabitacion==detalleReservaDescriptionDTO.IdHabitacion).FirstOrDefaultAsync();
            return detalle!=null;
        }   
    }
}
