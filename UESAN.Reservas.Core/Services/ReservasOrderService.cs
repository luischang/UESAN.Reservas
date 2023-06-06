using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;
using UESAN.Reservas.Infrastructure.Repositories;

namespace UESAN.Reservas.Core.Services
{
    public class ReservasOrderService : IReservasOrderService
    {
        private readonly IReservasOrderRepository _reservasOrderRepository;

        public ReservasOrderService(IReservasOrderRepository reservasOrderRepository)
        {
            _reservasOrderRepository = reservasOrderRepository;
        }

        public async Task<IEnumerable<ReservasOrderDescriptionDTO>> GetAll()
        {
            var reservasOrders = await _reservasOrderRepository.GetAll();
            var reservasOrdersDTO = new List<ReservasOrderDescriptionDTO>();

            foreach (var reservasOrder in reservasOrders)
            {
                var reservasOrderDTO = new ReservasOrderDescriptionDTO();
                reservasOrderDTO.IdReserva = reservasOrder.IdReserva;
                reservasOrderDTO.IdUsuario = reservasOrder.IdUsuario;
                reservasOrderDTO.FechaIni = reservasOrder.FechaIni;
                reservasOrderDTO.FechaFin = reservasOrder.FechaFin;
                reservasOrderDTO.IdEstadoRes = reservasOrder.IdEstadoRes;
                reservasOrderDTO.CantPersonas = reservasOrder.CantPersonas;
                reservasOrderDTO.IdOfertas = reservasOrder.IdOfertas;

                reservasOrdersDTO.Add(reservasOrderDTO);
            }
            return reservasOrdersDTO;
        }
        public async Task<ReservasOrderDTO> GetById(int id)
        {
            var reservasOrder = await _reservasOrderRepository.GetById(id);
            var reservasOrderDTO = new ReservasOrderDTO();
            reservasOrderDTO.IdReserva = reservasOrder.IdReserva;
            reservasOrderDTO.IdUsuario = reservasOrder.IdUsuario;
            reservasOrderDTO.FechaIni = reservasOrder.FechaIni;
            reservasOrderDTO.FechaFin = reservasOrder.FechaFin;
            reservasOrderDTO.IdEstadoRes = reservasOrder.IdEstadoRes;
            reservasOrderDTO.CantPersonas = reservasOrder.CantPersonas;
            reservasOrderDTO.IdOfertas = reservasOrder.IdOfertas;
            return reservasOrderDTO;
        }

        public async Task<bool> Insert(ReservasOrderInsertDTO reservasOrderInsertDTO)
        {
            var reservasOrder = new ReservasOrder();
            reservasOrder.FechaIni = reservasOrderInsertDTO.FechaIni;
            reservasOrder.FechaFin = reservasOrderInsertDTO.FechaFin;
            reservasOrder.CantPersonas = reservasOrderInsertDTO.CantPersonas;
            reservasOrder.IdOfertas = reservasOrderInsertDTO.IdOfertas;

            var result = await _reservasOrderRepository.Insert(reservasOrder);
            return result;
        }

        public async Task<bool> Update(ReservasOrderDescriptionDTO reservasOrderDescriptionDTO)
        {
            var reservasOrder = await _reservasOrderRepository.GetById(reservasOrderDescriptionDTO.IdReserva);
            if (reservasOrder == null)
                return false;
            reservasOrder.IdEstadoRes = reservasOrderDescriptionDTO.IdEstadoRes;

            var result = await _reservasOrderRepository.Update(reservasOrder);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var reservasOrder = await _reservasOrderRepository.GetById(id);
            if (reservasOrder == null)
                return false;

            var result = await _reservasOrderRepository.Delete(id);
            return result;
        }
    }
}
