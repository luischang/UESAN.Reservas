using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleServiciosRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleServicios>> GetAll();
        Task<DetalleServicios> GetById(int id);
        Task<bool> Insert(DetalleServicios detalleServicios);
        Task<bool> Update(DetalleServicios detalleServicios);
    }
}