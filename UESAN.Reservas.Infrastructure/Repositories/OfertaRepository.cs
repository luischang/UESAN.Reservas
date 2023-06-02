using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.Interfaces;

namespace UESAN.Reservas.Infrastructure.Repositories
{
    public class OfertaRepository : IOfertaRepository
    {
        private readonly YourDbContext dbContext;

        public OfertaRepository(YourDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Oferta GetById(int idOferta)
        {
            return dbContext.Ofertas.FirstOrDefault(o => o.IdOferta == idOferta);
        }

        public void Create(Oferta oferta)
        {
            dbContext.Ofertas.Add(oferta);
            dbContext.SaveChanges();
        }

        public void Update(Oferta oferta)
        {
            dbContext.Ofertas.Update(oferta);
            dbContext.SaveChanges();
        }

        public void Delete(Oferta oferta)
        {
            dbContext.Ofertas.Remove(oferta);
            dbContext.SaveChanges();
        }

    }
}
