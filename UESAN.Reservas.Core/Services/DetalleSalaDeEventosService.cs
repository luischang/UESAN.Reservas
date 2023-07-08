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
    public class DetalleSalaDeEventosService : IDetalleSalaDeEventosService
    {
        private readonly IDetalleSalaEventosRepository _detalleSalaEventosRepository;
        private readonly IReservasOrderRepository _reservasOrderRepository;
        private readonly ISalaDeEventosRepository _eventosRepository;

        public DetalleSalaDeEventosService(IDetalleSalaEventosRepository detalleSalaEventosRepository, ISalaDeEventosRepository eventosRepository, IReservasOrderRepository reservasOrderRepository)
        {
            _detalleSalaEventosRepository = detalleSalaEventosRepository;
            _eventosRepository = eventosRepository;
            _reservasOrderRepository = reservasOrderRepository; 
        }

        public async Task<IEnumerable<DetalleSalaDeEventosDTO>> GetAll()
        {
            var detalles = await _detalleSalaEventosRepository.GetAll();

            var detalleDTO = detalles.Select(e => new DetalleSalaDeEventosDTO
            {
                IdReserva = e.IdReserva,
                IdSalaEvento = e.IdSalaEvento,
                FechaInicio = e.FechaInicio,
                FechaFin = e.FechaFin,
                SubTotal = e.SubTotal,
            });
            return detalleDTO;

        }

        public async Task<DetalleSalaDeEventosDTO> GetById(int id)
        {
            var detalleSala = await _detalleSalaEventosRepository.GetByIdDetalleReserva(id);
            if (detalleSala != null)
            {
                var detalleSalaDTO = new DetalleSalaDeEventosDTO
                {
                    IdReserva = detalleSala.IdReserva,
                    IdSalaEvento = detalleSala.IdSalaEvento,
                    FechaInicio = detalleSala.FechaInicio,
                    FechaFin = detalleSala.FechaFin,
                    SubTotal = detalleSala.SubTotal

                };
                return detalleSalaDTO;
            }
            return null;
        }

        public async Task<bool> Insert(InsertDetalleSalaDeEventosDTO InsertDetalleSalaDeEventosDTO)
        {
            var precio = 0;
            var idSala = InsertDetalleSalaDeEventosDTO.IdSalaEvento;
            var idreserva = InsertDetalleSalaDeEventosDTO.IdReserva;
            var SalaEvento = await _eventosRepository.GetId(idSala);
            var reserva = await _reservasOrderRepository.GetById(idreserva);
            precio = (int)SalaEvento.Precio;

            if ( SalaEvento != null && reserva != null )
            {
                var detalleSalaEvento = new DetalleSalaEventos
				{
					IdReserva = InsertDetalleSalaDeEventosDTO.IdReserva,
					IdSalaEvento = InsertDetalleSalaDeEventosDTO.IdSalaEvento,
					FechaInicio = reserva.FechaIni,
					FechaFin = reserva.FechaFin,
					SubTotal = precio

				};
				return await _detalleSalaEventosRepository.Insert(detalleSalaEvento);
			}
            return false;
        }

        public async Task<bool> Update(DetalleSalaDeEventosDTO detalleSalaDeEventosDTO)
        {

            var reserva = new DetalleSalaEventos
            {
                IdSalaEvento = detalleSalaDeEventosDTO.IdSalaEvento,
                IdReserva = detalleSalaDeEventosDTO.IdReserva,
                SubTotal = detalleSalaDeEventosDTO.SubTotal,
                FechaInicio = detalleSalaDeEventosDTO.FechaInicio,
                FechaFin = detalleSalaDeEventosDTO.FechaFin
            };
            return await _detalleSalaEventosRepository.Update(reserva);

        }

        public async Task<bool> Delete(int id)
        {
            var detalleSala = await _detalleSalaEventosRepository.GetByIdDetalleReserva(id);
            if (detalleSala == null)
                return false;

            var result = await _detalleSalaEventosRepository.Delete(id);
            return result;
        }
    }
}
