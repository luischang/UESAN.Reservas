using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IServicioService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ServicioDescriptionDTO>> GetAll();
        Task<ServicioDTO> GetById(int id);
        Task<bool> Insert(ServicioInsertDTO servicioInsertDTO);
        Task<bool> Update(ServicioDescriptionDTO servicioDescriptionDTO);
    }
}