using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IReservasOrderService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ReservasOrderDescriptionDTO>> GetAll();
        Task<ReservasOrderDTO> GetById(int id);
        Task<int> Insert(ReservasOrderInsertarDTO reservasOrderInsertDTO);
        Task<bool> Update(ReservasOrderDescriptionDTO reservasOrderDescriptionDTO);
    }
}