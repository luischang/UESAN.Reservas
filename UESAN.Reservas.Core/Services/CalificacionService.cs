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
        private readonly ICalificacionRepository _calificacionRepository;

        public CalificacionService(ICalificacionRepository calificacionRepository)
        {
            _calificacionRepository = calificacionRepository;
        }

        public async Task<IEnumerable<CalificacionDTO>> GetAll()
        {
            var calificaciones = await _calificacionRepository.GetAll();
            var calificacionesDTO = new List<CalificacionDTO>();

            foreach (var calificacion in calificaciones)
            {
                var calificacionDTO = new CalificacionDTO();
                calificacionDTO.IdCalificacion = calificacion.IdCalificacion;
                calificacionDTO.IdReserva = calificacion.IdReserva;
                calificacionDTO.NumEstrellas = calificacion.NumEstrellas;
                calificacionDTO.Recomendacion = calificacion.Recomendacion;

                calificacionesDTO.Add(calificacionDTO);
            }
            return calificacionesDTO;
        }
        public async Task<CalificacionDTO> GetById(int id)
        {
            var calificacion = await _calificacionRepository.GetById(id);
            if (calificacion == null) { return null; }
            var calificacionDTO = new CalificacionDTO();
            calificacionDTO.IdCalificacion = calificacion.IdCalificacion;
            calificacionDTO.Recomendacion = calificacion.Recomendacion;
            calificacionDTO.NumEstrellas = calificacion.NumEstrellas;
            return calificacionDTO;
        }

        public async Task<bool> Insert(CalificacionInsertDTO calificacionInsertDTO)
        {
            var calificacion = new Calificacion();
            calificacion.Recomendacion = calificacionInsertDTO.Recomendacion;
            calificacion.NumEstrellas = calificacionInsertDTO.NumEstrellas;
            calificacion.IdReserva = calificacionInsertDTO.IdReserva;
            var result = await _calificacionRepository.Insert(calificacion);
            return result;
        }

        public async Task<bool> Update(CalificacionRecomendacionDTO calificacionRecomendacionDTO)
        {
            var calificacion = await _calificacionRepository.GetById(calificacionRecomendacionDTO.IdCalificacion);
            if (calificacion == null)
                return false;
            calificacion.Recomendacion = calificacionRecomendacionDTO.Recomendacion;

            var result = await _calificacionRepository.Update(calificacion);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var calificacion = await _calificacionRepository.GetById(id);
            if (calificacion == null)
                return false;

            var result = await _calificacionRepository.Delete(id);
            return result;
        }


    }
}
