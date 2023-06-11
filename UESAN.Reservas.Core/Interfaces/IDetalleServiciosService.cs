using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IDetalleServiciosService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<DetalleServiciosDescriptionDTO>> GetAll();
        Task<IEnumerable<DetalleServiciosDescriptionDTO>> GetById(int id);
        Task<bool> Insert(DetalleServiciosInsertDTO detalleServiciosInsertDTO);
        Task<bool> Update(DetalleServiciosDescriptionDTO detalleServiciosDescriptionDTO);
    }
}