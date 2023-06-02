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
            return MapPagoToDTO(pago);
        }

        public PagoDTO GuardarPago(PagoDTO pagoDTO)
        {
            var pago = MapDTOToPago(pagoDTO);
            pagoRepository.Create(pago);
            return MapPagoToDTO(pago);
        }

        public void ActualizarPago(PagoDTO pagoDTO)
        {
            var pago = MapDTOToPago(pagoDTO);
            pagoRepository.Update(pago);
        }

        public void EliminarPago(int idPago)
        {
            var pago = pagoRepository.GetById(idPago);
            if (pago != null)
                pagoRepository.Delete(pago);
        }

        private PagoDTO MapPagoToDTO(Pago pago)
        {
            return new PagoDTO
            {
                IdPago = pago.IdPago,
                IdReserva = pago.IdReserva,
                MetodoPago = pago.MetodoPago,
                MontoTotal = pago.MontoTotal,
                Estado = pago.Estado
            };
        }

        private Pago MapDTOToPago(PagoDTO pagoDTO)
        {
            return new Pago
            {
                IdPago = pagoDTO.IdPago,
                IdReserva = pagoDTO.IdReserva,
                MetodoPago = pagoDTO.MetodoPago,
                MontoTotal = pagoDTO.MontoTotal,
                Estado = pagoDTO.Estado
            };
        }
    }
}
