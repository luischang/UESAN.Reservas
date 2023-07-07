using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IHabitacionRepository
    {
        
        //Task<Habitacion> GetHabitacionById(int id);
        Task<IEnumerable<Habitacion>> GetHabitaciones();
        Task<Habitacion> GetHabitacionById(int id);
        Task<bool> Insert(Habitacion habitacion);
        Task<bool> Update(Habitacion habitacion);
        Task<bool> Delete(Habitacion habitacion);
    }
}