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
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        
        private readonly IReservasOrderRepository _reservas;
        

        public PagoService(IPagoRepository pagoRepository, IReservasOrderRepository reservasOrderRepository)
        {
            _pagoRepository = pagoRepository;
            _reservas = reservasOrderRepository;

        }

        public async Task<IEnumerable<PagoDescripcionDTO>> GetAll()
        {
            var pagos = await _pagoRepository.GetAll();
            var pagosDTO = new List<PagoDescripcionDTO>();

            foreach (var pago in pagos)
            {
                var pagoDTO = new PagoDescripcionDTO()
                {
                    IdPago = pago.IdPago,
                    IdReserva = pago.IdReserva,
                    Estado = pago.Estado,
                    MetodoPago = pago.MetodoPago,
                    MontoTotal = pago.MontoTotal

                };

                pagosDTO.Add(pagoDTO);
            }
            return pagosDTO;
        }

        public async Task<PagoDTO> GetById(int id)
        {

            var pago = await _pagoRepository.GetById(id);
            if (pago == null) { return null; }
            var pagoDTO = new PagoDTO()
            {
                IdPago = pago.IdPago,
                IdReserva = pago.IdReserva,
                Estado = pago.Estado,
                MetodoPago = pago.MetodoPago,
                MontoTotal = pago.MontoTotal
            };

            return pagoDTO;
        }

        public async Task<string> Insert(PagoInsertDTO pagoInsertDTO)
        {	
            
            
            var reser = await _reservas.GetById(pagoInsertDTO.IdReserva);
            var estado = true;
            //valido si la reserva  esta en su unico y primer pago
            var reservas = await _reservas.GetReservasPagadas();
            foreach (var item in reservas)
            {
                if (item.IdReserva == reser.IdReserva) {
                    estado = false;
                }
            }
            if(estado)
            {
				var pago = new Pago()
				{
					IdReserva = pagoInsertDTO.IdReserva,
					Estado = 1,
					MetodoPago = 1,
					MontoTotal = pagoInsertDTO.MontoTotal,
				};
				var result = await _pagoRepository.Insert(pago);

				if (result)
				{
					var cambio = await _reservas.EstadoC(reser.IdReserva);
					if (cambio)
                    {
						return "#el cambio en reserva y el pago se hicieron bien";
					}
                    return "Se creo el pago pero no se cambio el estado de la reserva";
				}
                return "El pago no se creo";
			}
            return " La reserva ya fue usada para un pago";
        }


        public async Task<bool> Update(PagoDescripcionDTO pagoDescripcionDTO)
        {
            var pago = await _pagoRepository.GetById(pagoDescripcionDTO.IdPago);
            if (pago == null)
                return false;
            pago.MetodoPago = pagoDescripcionDTO.MetodoPago;

            var result = await _pagoRepository.Update(pago);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var pago = await _pagoRepository.GetById(id);
            if (pago == null)
                return false;

            var result = await _pagoRepository.Delete(id);
            return result;
        }


    }
}
