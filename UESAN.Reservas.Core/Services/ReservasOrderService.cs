﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Reservas.Core.DTOs;
using UESAN.Reservas.Core.Entities;
using UESAN.Reservas.Core.Interfaces;


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

        public async Task<IEnumerable<ReservasOrderDTO>> ReservasPorUsuario(int idUsuario)
        {
            var reservasOrder = await _reservasOrderRepository.ReservasPorUsuario(idUsuario);
            var reservasOrderDTO = new List<ReservasOrderDTO>();

            foreach (var reservaOrder in reservasOrder)
            {
                var reservaOrderDTO = new ReservasOrderDTO();
                reservaOrderDTO.IdReserva = reservaOrder.IdReserva;
                reservaOrderDTO.IdUsuario = reservaOrder.IdUsuario;
                reservaOrderDTO.FechaIni = reservaOrder.FechaIni;
                reservaOrderDTO.FechaFin = reservaOrder.FechaFin;
                reservaOrderDTO.IdEstadoRes = reservaOrder.IdEstadoRes;
                reservaOrderDTO.CantPersonas = reservaOrder.CantPersonas;
                reservaOrderDTO.IdOfertas = reservaOrder.IdOfertas;
                reservasOrderDTO.Add(reservaOrderDTO);
            }
            return reservasOrderDTO;
        }

        public async Task<int> Insert(ReservasOrderInsertarDTO reservasOrderInsertDTO)
        {
            var reservasOrder = new ReservasOrder();
            reservasOrder.IdUsuario = reservasOrderInsertDTO.IdUsuario;
            reservasOrder.FechaIni = reservasOrderInsertDTO.FechaIni;
            reservasOrder.FechaFin = reservasOrderInsertDTO.FechaFin;
            reservasOrder.CantPersonas = reservasOrderInsertDTO.CantPersonas;
            reservasOrder.IdOfertas = reservasOrderInsertDTO.IdOfertas;
            reservasOrder.IdEstadoRes = reservasOrderInsertDTO.IdEstadoRes;

            var result = await _reservasOrderRepository.Insert(reservasOrder);
            //creamos un detalle reserva
            var reserva = reservasOrder.IdReserva;
            
           
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
