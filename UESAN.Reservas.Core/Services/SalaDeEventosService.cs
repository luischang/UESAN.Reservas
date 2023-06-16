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
    public class SalaDeEventosService : ISalaDeEventosService
    {
        private readonly ISalaDeEventosRepository _salaDeEventosRepository;

        public SalaDeEventosService(ISalaDeEventosRepository salaDeEventosRepository)
        {
            _salaDeEventosRepository = salaDeEventosRepository;
        }

        public async Task<IEnumerable<SalaDeEventosDTO>> GetAll()
        {
            var SalaEvento = await _salaDeEventosRepository.GetAll();
            var SalaEventoDTO = new List<SalaDeEventosDTO>();

            foreach (var salaDeEventos in SalaEvento)
            {
                var SalaEventosDTO = new SalaDeEventosDTO();
                SalaEventosDTO.IdSalaEvento = salaDeEventos.IdSalaEvento;
                SalaEventosDTO.Descripcion = salaDeEventos.Descripcion;
                SalaEventosDTO.Estado = salaDeEventos.Estado;
                SalaEventosDTO.Precio = salaDeEventos.Precio;
                SalaEventosDTO.IdTipoEvento = salaDeEventos.IdTipoEvento;
                SalaEventoDTO.Add(SalaEventosDTO);
            }
            return SalaEventoDTO;
        }

        public async Task<SalaDeEventosDTO> GetById(int id)
        {
            var SalaEvento = await _salaDeEventosRepository.GetId(id);
            if (SalaEvento == null)
                return null;
            var salaEventoDTO = new SalaDeEventosDTO()
            {
                IdSalaEvento = SalaEvento.IdSalaEvento,
                Descripcion = SalaEvento.Descripcion,
                Estado = SalaEvento.Estado,
                Precio = SalaEvento.Precio,
                IdTipoEvento = SalaEvento.IdTipoEvento
            };
            return salaEventoDTO;
        }

        public async Task<bool> Insert(InsertSalaDeEventosDTO insertSalaDeEventosDTO)
        {
            var saladeeventos = new SalaDeEventos();
            if (saladeeventos == null)
                return false;
            saladeeventos.Descripcion = insertSalaDeEventosDTO.Descripcion;
            saladeeventos.Estado = insertSalaDeEventosDTO.Estado;
            saladeeventos.Precio = insertSalaDeEventosDTO.Precio;
            saladeeventos.IdTipoEvento = insertSalaDeEventosDTO.IdTipoEvento;

            var result = await _salaDeEventosRepository.Update(saladeeventos);
            return result;
        }

        public async Task<bool> Update(SalaDeEventosDTO salaDeEventosDTO)
        {
            var SalaEvento = await _salaDeEventosRepository.GetId(salaDeEventosDTO.IdSalaEvento);

            if (SalaEvento == null)
                return false;
            SalaEvento.IdSalaEvento = SalaEvento.IdSalaEvento;
            SalaEvento.Descripcion = salaDeEventosDTO.Descripcion;
            SalaEvento.Estado = salaDeEventosDTO.Estado;
            SalaEvento.Precio = salaDeEventosDTO.Precio;
            SalaEvento.IdTipoEvento = salaDeEventosDTO.IdTipoEvento;

            var result = await _salaDeEventosRepository.Update(SalaEvento);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var salaEvento = await _salaDeEventosRepository.GetId(id);
            if (salaEvento == null)
                return false;
            salaEvento.Estado = false;

            var result = await _salaDeEventosRepository.Delete(salaEvento);
            return result;
        }



    }
}
