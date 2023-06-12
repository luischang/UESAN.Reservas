using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleReservasRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleReservas>> GetDetalleReservas();
        Task<DetalleReservas> GetDetalleReservasById(int e);
        Task<bool> getIds(DetalleReservaDescriptionDTO detalleReservaDescriptionDTO);
        Task<IEnumerable<DetalleReservas>> GetId(int id);
        Task<bool> Insert(DetalleReservas detallereservas);
        Task<bool> Update(DetalleReservas detalleReservas);
    }
}