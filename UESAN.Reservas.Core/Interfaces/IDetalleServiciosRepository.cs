using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleServiciosRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleServicios>> GetAll();
        Task<IEnumerable<DetalleServicios>> GetById(int id);
        Task<DetalleServicios>GetByIdupdate(int id);
        Task<bool> Insert(DetalleServicios detalleServicios);
        Task<bool> Update(DetalleServicios detalleServicios);
        Task<DetalleServicios> GetByIdOferta(int id);
    }
}