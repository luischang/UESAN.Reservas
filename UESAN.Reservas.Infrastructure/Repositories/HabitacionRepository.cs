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
    public class HabitacionRepository : IHabitacionRepository
    {
        private readonly ReservasContext _context;

        public HabitacionRepository(ReservasContext context)
        {
            _context = context;
        }

     
         public async Task<IEnumerable<Core.Entities.Habitacion>> GetHabitaciones()
        {
            var habitaciones= await _context.Habitacion.ToListAsync();
            return habitaciones;
        }
         

        public async Task<Habitacion> GetHabitacionById(int id)
        {
            var habitacion =await _context.Habitacion.Where(x => x.IdHabitacion == id).FirstOrDefaultAsync();
            if(habitacion == null)
            {
                throw new Exception("Habitación no encontrada");
            }
            return habitacion;

        }
         

        public async Task<bool> Insert(Habitacion habitacion)
        {
            await _context.Habitacion.AddAsync(habitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;

        }

        public async Task<bool> Update(Habitacion habitacion)
        {
            _context.Habitacion.Update(habitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
                return false;
            _context.Habitacion.Remove(habitacion);
            var countRows = await _context.SaveChangesAsync();
            return countRows >= 0;

        }

    }
}
