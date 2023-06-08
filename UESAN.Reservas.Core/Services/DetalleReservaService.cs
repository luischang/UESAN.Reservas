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
    public class DetalleReservaService : IDetalleReservaService
    {
        private readonly IDetalleReservasRepository _detalleReservasRepository;

        private readonly IHabitacionRepository _habitacionRepository;
        


        public DetalleReservaService(IDetalleReservasRepository detalleReservasRepository, IHabitacionRepository habitacionRepository)
        {
            _detalleReservasRepository = detalleReservasRepository;
            _habitacionRepository = habitacionRepository;
        

        }


        public async Task<IEnumerable<DetalleReservasDTO>> GetAll()
        {
            var detalles = await _detalleReservasRepository.GetDetalleReservas();

            var detalleDTO = detalles.Select(e => new DetalleReservasDTO
            {
                IdReserva = e.IdReserva,
                IdHabitacion = e.IdHabitacion,
                Subtotal = e.Subtotal,

            });
            return detalleDTO;

        }
        public async Task<DetalleReservasDTO> GetById(int id)
        {
            var detalle = await _detalleReservasRepository.GetDetalleReservasById(id);
            if (detalle == null)
                return null;
            var detalleDTO = new DetalleReservasDTO()
            {
                IdReserva = detalle.IdReserva,
                IdHabitacion = detalle.IdHabitacion,
                Subtotal = detalle.Subtotal,

            };
            return detalleDTO;
            ;
        }
        public async Task<bool> Insert(DetalleReservaInsertDTO detalleReservaInsertDTO, int id)
        {
            var habitacion = new HabitacionDetalleReservaInsertDTO
            {
                Descripcion = detalleReservaInsertDTO.HabitacionDetalle.Descripcion,
                Precio = detalleReservaInsertDTO.HabitacionDetalle.Precio,
                Id_Habitacion = detalleReservaInsertDTO.HabitacionDetalle.Id_Habitacion,
                TipoHabitacion = new TipoHabitacionDescriptionDTO
                {
                    Id_TipoHabi = detalleReservaInsertDTO.HabitacionDetalle.TipoHabitacion.Id_TipoHabi,
                    Descripcion = detalleReservaInsertDTO.HabitacionDetalle.TipoHabitacion.Descripcion,
                }
            };

            var habitacionE = await _habitacionRepository.GetHabitacionById(habitacion.Id_Habitacion);



            if (habitacion != null)
            {

                var detalleReserva = new DetalleReservas()
                {
                    IdReserva = id,
                    IdHabitacion = habitacion.Id_Habitacion,
                    Subtotal = habitacion.Precio,

                };
                return await _detalleReservasRepository.Insert(detalleReserva);

            }
            return false;
        }

    }
}
