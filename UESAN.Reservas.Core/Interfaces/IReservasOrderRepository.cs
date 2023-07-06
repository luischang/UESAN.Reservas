using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IReservasOrderRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ReservasOrder>> GetAll();
        Task<ReservasOrder> GetById(int id);
        Task<IEnumerable<ReservasOrder>> ReservasPorUsuario(int idUsuario);
        Task<int> Insert(ReservasOrder reservasOrder);
        Task<bool> Update(ReservasOrder reservasOrder);
        Task<bool> EstadoC(int id);
    }
}