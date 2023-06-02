using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Entities;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly YourDbContext dbContext;

        public CalificacionRepository(YourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Calificacion GetById(int idCalificacion)
        {
            return dbContext.Calificaciones.FirstOrDefault(c => c.IdCalificacion == idCalificacion);
        }

        public void Create(Calificacion calificacion)
        {
            dbContext.Calificaciones.Add(calificacion);
            dbContext.SaveChanges();
        }

        public void Update(Calificacion calificacion)
        {
            dbContext.Calificaciones.Update(calificacion);
            dbContext.SaveChanges();
        }

        public void Delete(Calificacion calificacion)
        {
            dbContext.Calificaciones.Remove(calificacion);
            dbContext.SaveChanges();
        }

    }
}
