using System;
using System.Collections.Generic;
using System.Diagnostics;
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
          var detallaReserva=await _detalleReservasRepository.GetDetalleReservasById(id);
            if (detallaReserva!=null)
            {
                var detalleDTO = new DetalleReservasDTO
                {
                    IdReserva = detallaReserva.IdReserva,
                    IdHabitacion = detallaReserva.IdHabitacion,
                    Subtotal = detallaReserva.Subtotal,

                };
                return detalleDTO;
            }
            return null;
        }
        public async Task<bool> Insert(DetalleReservasInsertDTO detalleReservaInsertDTO)
        {
            var precio = 0;
            var habitacion = await _habitacionRepository.GetHabitacionById((int)(detalleReservaInsertDTO.IdHabitacion));
            precio = (int)habitacion.Precio;
            var detalleReserva = new DetalleReservas
            {
                IdReserva = detalleReservaInsertDTO.IdReserva,
                IdHabitacion = detalleReservaInsertDTO.IdHabitacion,
                Subtotal = precio

            };
            return await _detalleReservasRepository.Insert(detalleReserva);
        }

        public async Task<bool> Update(DetalleReservaDescriptionDTO detalleReservaDescriptionDTO)
        {
     
                var reserva = new DetalleReservas
                {
                    IdHabitacion=detalleReservaDescriptionDTO.IdHabitacion,
                    IdReserva=detalleReservaDescriptionDTO.IdReserva,
                    Subtotal=detalleReservaDescriptionDTO.SubTotal,
                };
                return await _detalleReservasRepository.Update(reserva);
          
        }

        public async Task<bool> Delete(int id)
        {
            var detalleReservas = await _detalleReservasRepository.GetDetalleReservasById(id);
            if (detalleReservas == null)
                return false;

            var result = await _detalleReservasRepository.Delete(id);
            return result;
        }

    }
}
