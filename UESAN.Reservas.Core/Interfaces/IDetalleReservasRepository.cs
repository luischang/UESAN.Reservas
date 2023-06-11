using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleReservasRepository
    {
        Task<IEnumerable<DetalleReservas>> GetDetalleReservas();
        Task<DetalleReservas> GetDetalleReservasById(int id);
        Task<bool> Insert(DetalleReservas detallereservas);
        Task<IEnumerable<DetalleReservas>> GetId(int id);
    }
}