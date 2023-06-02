using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoUsuario>> GetAll();
        Task<TipoUsuario> GetById(int id);
        Task<bool> Insert(TipoUsuario tipoUsuario);
        Task<bool> Update(TipoUsuario tipoUsuario);
    }
}