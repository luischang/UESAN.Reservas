using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleReservasRepository
    {
        Task<bool> Delete(int id);
        IEnumerable<DetalleReservas> GetDetalleReservas();
        DetalleReservas GetDetalleReservasById(int id);
        Task<bool> Insert(DetalleReservas detallereservas);
        Task<bool> Update(DetalleReservas detallereservas);
    }
}