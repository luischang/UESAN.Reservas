using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ISalaDeEventosService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<SalaDeEventosDTO>> GetAll();
        Task<SalaDeEventosDTO> GetById(int id);
        Task<bool> Insert(InsertSalaDeEventosDTO insertSalaDeEventosDTO);
        Task<bool> Update(SalaDeEventosDTO salaDeEventosDTO);
    }
}