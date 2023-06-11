using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;

namespace UESAN.Reservas.Core.Interfaces
{
    public interface IOfertasService
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<OfertasDescripcionDTO>> GetAll();
        Task<OfertasDTO> GetById(int id);
        Task<bool> Insert(OfertasInsertDTO ofertasInsertDTO);
        Task<bool> Update(OfertasDescripcionDTO ofertasDescripcionDTO);
    }
}
