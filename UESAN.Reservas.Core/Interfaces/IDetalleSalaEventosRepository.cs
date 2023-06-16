using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleSalaEventosRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleSalaEventos>> GetAll();
        Task<DetalleSalaEventos> GetByIdDetalleReserva(int e);
        Task<IEnumerable<DetalleSalaEventos>> GetId(int id);
        Task<bool> getIds(DescripDetalleSalaDeEventoDTO detalleSalaEventosDTO);
        Task<bool> Insert(DetalleSalaEventos detalleSalaEventos);
        Task<bool> Update(DetalleSalaEventos detalleSalaEventos);
    }
}