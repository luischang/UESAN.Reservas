using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IReservasOrderService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ReservasOrderDescriptionDTO>> GetAll();
        Task<ReservasOrderDTO> GetById(int id);
        Task<bool> Insert(ReservasOrderInsertDTO reservasOrderInsertDTO);
        Task<bool> Update(ReservasOrderDescriptionDTO reservasOrderDescriptionDTO);
    }
}