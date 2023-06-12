using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ITipoHabitacionService
    {
        Task<IEnumerable<TipoHabitacionDTO>> GetAll();
        Task<TipoHabitacionDTO> GetById(int id);

        Task<bool> Delete(int id);
        Task<bool> Insert(TipoHabitacionInsertDTO tipoHabitacionInsertDTO);
        Task<bool> Update(TipoHabitacionDescriptionDTO tipoHabitacionDescriptionDTO);
    }
}