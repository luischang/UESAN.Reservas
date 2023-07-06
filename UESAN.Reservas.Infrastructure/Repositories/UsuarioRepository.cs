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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ReservasContext _dbContext;

        public UsuarioRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> SignIn(string email, string clave)
        {
            var user = await _dbContext
                .Usuario
                .Where(x => x.Email == email && x.Contraseña == clave && x.Estado == true).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> SignUp(Usuario user)
        {
            await _dbContext.Usuario.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            return await _dbContext
                .Usuario
                .Where(x => x.Email == email).AnyAsync();
        }
        public async Task<int> GetLastUserId()
        {
            // Realizar una consulta para obtener el último IdUsuario de la tabla de usuarios
            var lastUserId = await _dbContext.Usuario
                .OrderByDescending(u => u.IdUsuario)
                .Select(u => u.IdUsuario)
                .FirstOrDefaultAsync();

            return lastUserId;
        }
        public async Task<IEnumerable<Usuario>> GetById(int idUsuario)
        {
            return await _dbContext.Usuario
      .Where(x => x.IdUsuario == idUsuario).ToListAsync();

        }
    }
}
