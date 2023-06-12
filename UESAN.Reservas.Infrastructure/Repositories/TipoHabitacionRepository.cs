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
    public class TipoHabitacionRepository : ITipoHabitacionRepository
    {
        private readonly ReservasContext _context;

        public TipoHabitacionRepository(ReservasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoHabitacion>> GetAll()
        {
            var tipohabitaciones = await _context.TipoHabitacion.Where(x => x.IdTipoHabi > 0).ToListAsync();
            return tipohabitaciones;
        }


        public async Task<TipoHabitacion> GetTipoHabitacionById(int id)
        {
            var tipohabitacion = await _context.TipoHabitacion.Where(x => x.IdTipoHabi == id).FirstOrDefaultAsync();
            if (tipohabitacion == null)
            {
                return null;
            }
            return tipohabitacion;

        }



        public async Task<bool> Insert(TipoHabitacion tipohabitacion)
        {
            await _context.TipoHabitacion.AddAsync(tipohabitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;

        }

        public async Task<bool> Update(TipoHabitacion tipohabitacion)
        {
            _context.TipoHabitacion.Update(tipohabitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var tipoHabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipoHabitacion != null)
            {
                _context.TipoHabitacion.Remove(tipoHabitacion);
                int rows = await _context.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }

    }
}
