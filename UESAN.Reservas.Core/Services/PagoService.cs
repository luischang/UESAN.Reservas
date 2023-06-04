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
        private readonly IPagoRepository pagoRepository;

        public PagoService(IPagoRepository pagoRepository)
        {
            this.pagoRepository = pagoRepository;
        }

        public PagoDTO ObtenerPago(int idPago)
        {
            var pago = pagoRepository.GetById(idPago);
            if (pago == null)
                return null;

            return new PagoDTO(pago.IdPago, pago.IdReserva.GetValueOrDefault(), pago.MetodoPago.GetValueOrDefault(), pago.MontoTotal.GetValueOrDefault(), pago.Estado.GetValueOrDefault());
        }

        public PagoDTO GuardarPago(PagoDTO pagoDTO)
        {
            var pago = new Pago
            {
                IdPago = pagoDTO.IdPago,
                IdReserva = pagoDTO.IdReserva,
                MetodoPago = pagoDTO.MetodoPago,
                MontoTotal = pagoDTO.MontoTotal,
                Estado = pagoDTO.Estado
            };

            pagoRepository.Create(pago);

            return new PagoDTO(pago.IdPago, pago.IdReserva.GetValueOrDefault(), pago.MetodoPago.GetValueOrDefault(), pago.MontoTotal.GetValueOrDefault(), pago.Estado.GetValueOrDefault());
        }

        public void ActualizarPago(PagoDTO pagoDTO)
        {
            var pago = pagoRepository.GetById(pagoDTO.IdPago);
            if (pago == null)
                return;

            pago.IdReserva = pagoDTO.IdReserva;
            pago.MetodoPago = pagoDTO.MetodoPago;
            pago.MontoTotal = pagoDTO.MontoTotal;
            pago.Estado = pagoDTO.Estado;

            pagoRepository.Update(pago);
        }

        public void EliminarPago(int idPago)
        {
            var pago = pagoRepository.GetById(idPago);
            if (pago != null)
                pagoRepository.Delete(pago);
        }
    }
}
