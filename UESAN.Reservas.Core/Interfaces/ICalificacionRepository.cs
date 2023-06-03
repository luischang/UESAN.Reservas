namespace UESAN.Reservas.Core.Interfaces
{
    public interface ICalificacionRepository
    {
        Calificacion GetById(int idCalificacion);
        void Create(Calificacion calificacion);
        void Update(Calificacion calificacion);
        void Delete(Calificacion calificacion);

    }
}