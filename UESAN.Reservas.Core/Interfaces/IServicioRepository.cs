﻿using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public interface IServicioRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Servicio>> GetAll();
        Task<Servicio> GetById(int id);
        Task<bool> Insert(Servicio servicio);
        Task<bool> Update(Servicio servicio);
    }
}