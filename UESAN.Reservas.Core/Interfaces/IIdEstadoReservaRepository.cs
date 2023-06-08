using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IIdEstadoReservaRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<IdEstadoReserva>> GetAll();
        Task<IdEstadoReserva> GetById(int id);
        Task<bool> Insert(IdEstadoReserva idEstadoReserva);
        Task<bool> Update(IdEstadoReserva idEstadoReserva);
    }
}