using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> Register(UsuarioAuthRequestDTO userDTO);
        Task<UsuarioAuthResponseDTO> Validate(string email, string password);
    }
}