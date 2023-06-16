using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleSalaDeEventosService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleSalaDeEventosDTO>> GetAll();
        Task<DetalleSalaDeEventosDTO> GetById(int id);
        Task<bool> Insert(InsertDetalleSalaDeEventosDTO InsertDetalleSalaDeEventosDTO);
        Task<bool> Update(DetalleSalaDeEventosDTO detalleSalaDeEventosDTO);
    }
}