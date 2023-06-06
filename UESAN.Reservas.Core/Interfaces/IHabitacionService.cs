using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IHabitacionService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<HabitacionTipoHabitacionDTO>> GetAll();
        Task<HabitacionTipoHabitacionDTO> GetById(int id);
        Task<bool> Insert(HabitacionInsertDTO habitacionInsertDTO);
        Task<bool> Update(HabitacionUpdateDTO habitacionUpdateDTO);
    }
}