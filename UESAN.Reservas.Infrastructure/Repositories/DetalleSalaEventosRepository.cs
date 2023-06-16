using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Infrastructure.Data;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class DetalleSalaEventosRepository : IDetalleSalaEventosRepository
    {
        private readonly ReservasContext _reservasContext;

        public DetalleSalaEventosRepository(ReservasContext reservasContext)
        {
            _reservasContext = reservasContext;
        }

        public async Task<IEnumerable<DetalleSalaEventos>> GetAll()
        {
            return await _reservasContext.DetalleSalaEventos
               .Where(x => x.IdReserva > 0)
               .Include(z => z.IdReservaNavigation)
               .Include(i => i.IdSalaEventoNavigation)
               .ToListAsync();

        }

        public async Task<DetalleSalaEventos> GetByIdDetalleReserva(int e)
        {
            return await _reservasContext.DetalleSalaEventos.Where(x => x.IdReserva == e)
                .Include(z => z.IdReservaNavigation)
                .Include(i => i.IdSalaEventoNavigation)
                .FirstOrDefaultAsync();

        }

        public async Task<bool> Insert(DetalleSalaEventos detalleSalaEventos)
        {
            await _reservasContext.DetalleSalaEventos.AddAsync(detalleSalaEventos);
            var countRows = await _reservasContext.SaveChangesAsync();
            return countRows > 0;

        }

        public async Task<bool> Update(DetalleSalaEventos detalleSalaEventos)
        {
            _reservasContext.DetalleSalaEventos.Update(detalleSalaEventos);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }



        public async Task<bool> Delete(int id)
        {
            var detalleSalaEventos = await _reservasContext.DetalleSalaEventos.FindAsync(id);
            if (detalleSalaEventos == null)
                return false;
            _reservasContext.DetalleSalaEventos.Remove(detalleSalaEventos);
            var countRows = await _reservasContext.SaveChangesAsync();
            return countRows >= 0;

        }

        //metodos extras

        public async Task<IEnumerable<DetalleSalaEventos>> GetId(int id)
        {
            var detalleSalaEvento = await _reservasContext.DetalleSalaEventos.Where(x => x.IdReserva == id).ToListAsync();
            return detalleSalaEvento;
        }

        public async Task<bool> getIds(DescripDetalleSalaDeEventoDTO detalleSalaEventosDTO)
        {
            var detalle = await _reservasContext.DetalleSalaEventos
                .Where(x => x.IdReserva == detalleSalaEventosDTO.IdReserva && x.IdSalaEvento == detalleSalaEventosDTO.IdSalaEvento)
                .FirstOrDefaultAsync();
            return detalle != null;
        }


    }
}
