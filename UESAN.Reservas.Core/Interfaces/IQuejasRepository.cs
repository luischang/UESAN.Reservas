using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IQuejasRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Quejas>> GetAll();
        Task<IEnumerable<Quejas>> QuejasPorUsuario(int idUsuario);
        Task<IEnumerable<Quejas>> GetByFecha(string fecha);
        Task<Quejas> GetID(int id);
        Task<bool> Insert(Quejas quejas);
        Task<bool> Update(Quejas quejas);
    }
}