using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IIdEstadoReservaService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<IdEstadoReservaDescriptionDTO>> GetAll();
        Task<IdEstadoReservaDTO> GetById(int id);
        Task<bool> Insert(IdEstadoReservaInsertDTO idEstadoReservaInsertDTO);
        Task<bool> Update(IdEstadoReservaDescriptionDTO idEstadoReservaDescriptionDTO);
    }
}