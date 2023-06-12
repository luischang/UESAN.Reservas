using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleReservaService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleReservasDTO>> GetAll();
        Task<DetalleReservasDTO> GetById(int id);
        Task<bool> Insert(DetalleReservasInsertDTO detalleReservaInsertDTO);
        Task<bool> Update(DetalleReservaDescriptionDTO detalleReservaDescriptionDTO);
    }
}