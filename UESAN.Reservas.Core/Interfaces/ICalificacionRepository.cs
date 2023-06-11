using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ICalificacionRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Calificacion>> GetAll();
        Task<Calificacion> GetById(int id);
        Task<bool> Insert(Calificacion calificacion);
        Task<bool> Update(Calificacion calificacion);

    }
}