using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ITipoHabitacionRepository
    {
        Task<bool> Delete(int id);
        TipoHabitacion GetTipoHabitacionById(int id);
        IEnumerable<TipoHabitacion> GetTipoHabitaciones();
        Task<bool> Insert(TipoHabitacion tipohabitacion);
        Task<bool> Update(TipoHabitacion tipohabitacion);
    }
}