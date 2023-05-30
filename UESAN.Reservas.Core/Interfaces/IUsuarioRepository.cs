using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> IsEmailRegistered(string email);
        Task<Usuario> SignIn(string email, string clave);
        Task<bool> SignUp(Usuario user);
        Task<int> GetLastUserId();
    }
}