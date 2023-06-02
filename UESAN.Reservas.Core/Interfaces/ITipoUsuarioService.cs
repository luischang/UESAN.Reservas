using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ITipoUsuarioService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoUsuarioDTO>> GetAll();
        Task<TipoUsuarioDTO> GetById(int id);
        Task<bool> Insert(InsertTipoUsuarioDTO insertipoUsuarioDTO);
        Task<bool> Update(TipoUsuarioDTO tipoUsuarioDTO);
    }
}