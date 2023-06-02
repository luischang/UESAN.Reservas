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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly ReservasContext _reservasContext;

        public TipoUsuarioRepository(ReservasContext reservasContext)
        {
            _reservasContext = reservasContext;
        }
        public async Task<IEnumerable<TipoUsuario>> GetAll()
        {
            return await _reservasContext.TipoUsuario.ToListAsync();
        }

        public async Task<TipoUsuario> GetById(int id)
        {
            return await _reservasContext.TipoUsuario.Where(x => x.IdTipo == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(TipoUsuario tipoUsuario)
        {
            await _reservasContext.TipoUsuario.AddAsync(tipoUsuario);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(TipoUsuario tipoUsuario)
        {
            _reservasContext.TipoUsuario.Update(tipoUsuario);
            int rows = await _reservasContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var TipUsuario = await _reservasContext.TipoUsuario.FindAsync(id);
            if (TipUsuario != null)
            {
                _reservasContext.TipoUsuario.Remove(TipUsuario);
                int rows = await _reservasContext.SaveChangesAsync();
                return rows > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
