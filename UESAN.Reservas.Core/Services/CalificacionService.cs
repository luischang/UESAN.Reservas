using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
namespace UESAN.Reservas.Core.Services
{
    public class CalificacionService : ICalificacionService
    {
        private readonly ICalificacionRepository calificacionRepository;

        public CalificacionService(ICalificacionRepository calificacionRepository)
        {
            this.calificacionRepository = calificacionRepository;
        }

        public CalificacionDTO GuardarCalificacion(CalificacionDTO calificacionDTO)
        {
            var calificacion = new Calificacion
            {
                IdCalificacion = calificacionDTO.IdCalificacion,
                IdReserva = calificacionDTO.IdReserva,
                NumEstrellas = calificacionDTO.NumEstrellas,
                Recomendacion = calificacionDTO.Recomendacion
            };

            calificacionRepository.Create(calificacion);


            return calificacionDTO;
        }

    }
}
