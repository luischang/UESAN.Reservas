using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UESAN.Reservas.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioAuthResponseDTO> Validate(string email, string password)
        {
            var user = await _usuarioRepository.SignIn(email, password);
            if (user == null)
                return null;

            var userDTO = new UsuarioAuthResponseDTO()
            {
                IdUsuario = user.IdUsuario,
                Email = user.Email,
                Contraseña = user.Contraseña,
                IdTipo = user.IdTipo,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Direccion = user.Direccion,
                Telefono = user.Telefono,
                Estado = user.Estado,
                Puntos = user.Puntos,
            };
            return userDTO;
        }

        public async Task<bool> Register(UsuarioAuthRequestDTO userDTO)
        {
            //Validación para registro
            var emaiResult = await _usuarioRepository.IsEmailRegistered(userDTO.Email);
            if (emaiResult)
                return false;
            bool isAdminEmail = userDTO.Email.EndsWith("@admin.com");
            //int lastUserId = await _usuarioRepository.GetLastUserId();
            //int newUserId = lastUserId + 1;

            var user = new Usuario()
            {
                Email = userDTO.Email,
                Contraseña = userDTO.Contraseña,
                IdTipo = isAdminEmail ? 1 : 2,
                Nombre = userDTO.Nombre,
                Apellido = userDTO.Apellido,
                Direccion = userDTO.Direccion,
                Telefono = userDTO.Telefono,
                Estado = true,
                Puntos = 0
            };

            var result = await _usuarioRepository.SignUp(user);
            return result;
        }
        public async Task<IEnumerable<Usuario>> GetById(int idUsuario)
        {
            var user = await _usuarioRepository.GetById(idUsuario);

            if (user == null)
                return null;

            return user;

        }
    }
}