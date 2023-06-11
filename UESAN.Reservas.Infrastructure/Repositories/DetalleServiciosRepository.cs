using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure.Data;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class DetalleServiciosRepository : IDetalleServiciosRepository
    {
        private readonly ReservasContext _dbContext;

        public DetalleServiciosRepository(ReservasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DetalleServicios>> GetAll()
        {
            return await _dbContext
                         .DetalleServicios
                         //.Where(x => x.IdEstadoRes == true)
                         .ToListAsync();
        }

        public async Task<IEnumerable<DetalleServicios>> GetById(int id)
        {
            return await _dbContext
                        .DetalleServicios
                        .Where(x => x.IdReserva == id)
                        .ToListAsync();
        }


        public async Task<DetalleServicios> GetByIdupdate(int id)
        {
            return await _dbContext
                        .DetalleServicios
                        .Where(x => x.IdReserva == id)
                        .FirstOrDefaultAsync();
        }









        public async Task<DetalleServicios> GetByIdOferta(int id)
        {
            return await _dbContext.DetalleServicios.Where(x => x.IdServicio == id).FirstOrDefaultAsync();
        }
        public async Task<bool> Insert(DetalleServicios detalleServicios)
        {
            await _dbContext.DetalleServicios.AddAsync(detalleServicios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Update(DetalleServicios detalleServicios)
        {
            _dbContext.DetalleServicios.Update(detalleServicios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> Delete(int id)
        {
            //            var findDetalleServicios = await _dbContext
            //                                .DetalleServicios
            //                                .Where(x => x.IdReserva == id)
            //                                .FirstOrDefaultAsync();
            //            if (findDetalleServicios == null)
            //            return false;

            //            //findDetalleServicios.IdEstadoRes = false;

            //            var result = await _dbContext.DetalleServicios.Delete(findDetalleServicios);

            //            int rows = await _dbContext.SaveChangesAsync();
            //            return rows > 0;

            var findDetalleServicios = await _dbContext.DetalleServicios.FindAsync(id);
            if (findDetalleServicios == null)
                return false;

            _dbContext.DetalleServicios.Remove(findDetalleServicios);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
