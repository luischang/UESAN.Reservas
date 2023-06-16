using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface ISalaDeEventosRepository
    {
        Task<bool> Delete(SalaDeEventos salaDeEventos);
        Task<IEnumerable<SalaDeEventos>> GetAll();
        Task<SalaDeEventos> GetId(int id);
        Task<bool> Insert(SalaDeEventos salaDeEventos);
        Task<bool> Update(SalaDeEventos salaDeEventos);
    }
}