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
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly ReservasContext dbContext;

        public CalificacionRepository(ReservasContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Calificacion GetById(int idCalificacion)
        {
            return dbContext.Calificacion.Where(c => c.IdCalificacion == idCalificacion).FirstOrDefault();
        }

        public void Create(Calificacion calificacion)
        {
            dbContext.Calificacion.Add(calificacion);
            dbContext.SaveChanges();
        }

        public void Update(Calificacion calificacion)
        {
            dbContext.Calificacion.Update(calificacion);
            dbContext.SaveChanges();
        }

        public void Delete(Calificacion calificacion)
        {
            dbContext.Calificacion.Remove(calificacion);
            dbContext.SaveChanges();
        }

    }
}
