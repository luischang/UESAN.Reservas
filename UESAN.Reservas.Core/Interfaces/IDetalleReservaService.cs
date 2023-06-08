using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleReservaService
    {
        Task<IEnumerable<DetalleReservasDTO>> GetAll();
        Task<DetalleReservasDTO> GetById(int id);
        Task<bool> Insert(DetalleReservaInsertDTO detalleReservaInsertDTO, int id);
    }
}