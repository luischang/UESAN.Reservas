using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Register(UsuarioAuthRequestDTO userDTO);
        Task<UsuarioAuthResponseDTO> Validate(string email, string password);
        Task<IEnumerable<Usuario>> GetById(int idUsuario);
    }
}