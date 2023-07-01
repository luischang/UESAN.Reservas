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
        private readonly IDetalleServiciosRepository _repo;
        private readonly IDetalleReservasRepository _reservasRepository;
        private readonly IOfertasRepository _oferta;
        private readonly IReservasOrderRepository _reservas;
        private readonly IDetalleSalaEventosRepository _salaEventos;

        public PagoService(IPagoRepository pagoRepository, IDetalleServiciosRepository detalleServiciosRepository, IDetalleReservasRepository detalleReservasRepository, IOfertasRepository oferta, IReservasOrderRepository reservasOrderRepository, IDetalleSalaEventosRepository detalleSalaEventosRepository)
        {
            _pagoRepository = pagoRepository;
            _repo = detalleServiciosRepository;
            _reservasRepository = detalleReservasRepository;
            _oferta = oferta;
            _reservas = reservasOrderRepository;
            _salaEventos = detalleSalaEventosRepository;

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

        public async Task<bool> Insert(PagoInsertDTO pagoInsertDTO)
        {
            var acum1 = 0.0;
            var acum2 = 0.0;
            var acum3 = 0.0;
            var descuento = 0.0;
            //Primero traemos todos lo detalles servicios que estan registrados con la reserva creada
            var detallesS = await _repo.GetById(pagoInsertDTO.IdReserva);
            //traemos lo detalles reservas con el idReserva
            var detallesR = await _reservasRepository.GetId(pagoInsertDTO.IdReserva);

            var detallesSal = await _salaEventos.GetId(pagoInsertDTO.IdReserva);

            //Traemos la oferta la que esta expuesta la reserva
            var reser = await _reservas.GetById(pagoInsertDTO.IdReserva);

            var oferta = await _oferta.GetByIdOferta(reser.IdOfertas);
            //asignamos decuento
            
            if (oferta != null)
            {
                descuento = (double)oferta.Descuento;
            }

            foreach (var det in detallesS)//aqui traemos los detalles y extraemos sus precios
            {
                if (det.SubTotal != null)
                {
                    acum1 = acum1 + (int)det.SubTotal;
                }
            }
            foreach (var deta in detallesR)
            {
                if (deta.Subtotal != null)
                {
                    acum2 = acum2 + (int)deta.Subtotal;
                }
            }
            foreach (var detaSala in detallesSal)
            {
                if (detaSala.SubTotal != null)
                {
                    acum3 = acum3 + (int)detaSala.SubTotal;
                }
            }


            var pagoTotal = (acum1 + acum2 + acum3) - descuento;
            var pago = new Pago()
            {
                IdReserva = pagoInsertDTO.IdReserva,
                Estado = pagoInsertDTO.Estado,
                MetodoPago = 1,
                MontoTotal = (decimal)pagoTotal,
            };
            var result = await _pagoRepository.Insert(pago);

            if (result ){
                var cambio = await _reservas.EstadoC(reser.IdReserva);
                
                return result && cambio;
            }
            return false;
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
