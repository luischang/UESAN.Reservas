using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IQuejasService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<QuejasDTO>> GetAll();
        Task<IEnumerable<QuejasDTO>> QuejasPorUsuario(int idUsuario);
        Task<bool> Insert(InsertQuejasDTO insertQuejasDTO);
        Task<bool> Update(QuejasDTO quejasDTO);
    }
}