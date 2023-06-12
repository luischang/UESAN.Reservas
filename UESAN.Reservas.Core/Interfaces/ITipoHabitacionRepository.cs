using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ITipoHabitacionRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<TipoHabitacion>> GetAll();
        Task<TipoHabitacion> GetTipoHabitacionById(int id);
        Task<bool> Insert(TipoHabitacion tipohabitacion);
        Task<bool> Update(TipoHabitacion tipoHabitacion);
    }
}