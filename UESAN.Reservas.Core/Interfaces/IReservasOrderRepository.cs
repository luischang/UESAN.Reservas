using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public interface IReservasOrderRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ReservasOrder>> GetAll();
        Task<ReservasOrder> GetById(int id);
        Task<bool> Insert(ReservasOrder reservasOrder);
        Task<bool> Update(ReservasOrder reservasOrder);
    }
}