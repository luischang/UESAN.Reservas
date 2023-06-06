using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IHabitacionRepository
    {
        Task<bool> Delete(int id);
        Task<Habitacion> GetHabitacionById(int id);
        Task<IEnumerable<Habitacion>> GetHabitaciones();
        Task<bool> Insert(Habitacion habitacion);
        Task<bool> Update(Habitacion habitacion);
    }
}