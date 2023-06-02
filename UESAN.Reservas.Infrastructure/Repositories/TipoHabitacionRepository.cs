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
    public class TipoHabitacionRepository : ITipoHabitacionRepository
    {
        private readonly ReservasContext _context;

        public TipoHabitacionRepository(ReservasContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Entities.TipoHabitacion> GetTipoHabitaciones()
        {
            var tipohabitaciones = _context.TipoHabitacion.ToList();
            return tipohabitaciones;
        }

        //asincrono
        /*
         public async Task<IEnumerable<Core.Entities.TipoHabitacion>> GetTipoHabitaciones()
        {
            var tipohabitaciones= await _context.TipoHabitacion.ToListAsync();
            return tipohabitaciones;
        }
         */

        public TipoHabitacion GetTipoHabitacionById(int id)
        {
            var tipohabitacion = _context.TipoHabitacion.Where(x => x.IdTipoHabi == id).FirstOrDefault();
            if (tipohabitacion == null)
            {
                throw new Exception("Tipo de habitación no encontrada");
            }
            return tipohabitacion;

        }
        //asincrono
        /*
          public async Task<TipoHabitacion> GetTipoHabitacionById(int id)
        {
            var tipohabitacion =await _context.TipoHabitacion.Where(x => x.IdTipoHabi == id).FirstOrDefaultAsync();
            if(tipohabitacion == null)
            {
                throw new Exception("tipo de habitación no encontrada");
            }
            return tipohabitacion;

        }
         */

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
            var tipohabitacion = await _context.TipoHabitacion.FindAsync(id);
            if (tipohabitacion == null)
                return false;
            _context.TipoHabitacion.Remove(tipohabitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows >= 0;

        }
    }
}
