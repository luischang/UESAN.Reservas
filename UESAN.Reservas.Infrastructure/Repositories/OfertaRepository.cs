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
    public class OfertaRepository : IOfertaRepository
    {
        private readonly ReservasContext dbContext;

        public OfertaRepository(ReservasContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Ofertas GetById(int idOferta)
        {
            return dbContext.Ofertas.FirstOrDefault(o => o.IdOfertas == idOferta);
        }

        public void Create(Ofertas oferta)
        {
            dbContext.Ofertas.Add(oferta);
            dbContext.SaveChanges();
        }

        public void Update(Ofertas oferta)
        {
            dbContext.Ofertas.Update(oferta);
            dbContext.SaveChanges();
        }

        public void Delete(Ofertas oferta)
        {
            dbContext.Ofertas.Remove(oferta);
            dbContext.SaveChanges();
        }

    }
}
