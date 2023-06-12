using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IPagoService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<PagoDescripcionDTO>> GetAll();
        Task<PagoDTO> GetById(int id);
        Task<bool> Insert(PagoInsertDTO pagoInsertDTO);
        Task<bool> Update(PagoDescripcionDTO pagoDescripcionDTO);
    }
}