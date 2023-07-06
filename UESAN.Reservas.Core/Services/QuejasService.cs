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
    public class QuejasService : IQuejasService
    {
        private readonly IQuejasRepository _quejasRepository;

        public QuejasService(IQuejasRepository quejasRepository)
        {
            _quejasRepository = quejasRepository;
        }

        public async Task<IEnumerable<QuejasDTO>> GetAll()
        {
            var quejas = await _quejasRepository.GetAll();
            var quejasDTO = new List<QuejasDTO>();

            foreach (var queja in quejas)
            {
                var quejaDTO = new QuejasDTO();
                quejaDTO.IdQuejas = queja.IdQuejas;
                quejaDTO.Descripcion = queja.Descripcion;
                quejaDTO.IdUsuario = queja.IdUsuario;
                quejaDTO.Fecha = queja.Fecha;
                quejasDTO.Add(quejaDTO);
            }
            return quejasDTO;
        }
        public async Task<IEnumerable<QuejasDTO>> QuejasPorUsuario(int idUsuario)
        {
            var quejas = await _quejasRepository.QuejasPorUsuario(idUsuario);
            var quejasDTO = new List<QuejasDTO>();

            foreach (var queja in quejas)
            {
                var quejaDTO = new QuejasDTO();
                quejaDTO.IdQuejas = queja.IdQuejas;
                quejaDTO.Descripcion = queja.Descripcion;
                quejaDTO.IdUsuario = queja.IdUsuario;
                quejaDTO.Fecha = queja.Fecha;
                quejasDTO.Add(quejaDTO);
            }
            return quejasDTO;
        }

        public async Task<bool> Insert(InsertQuejasDTO insertQuejasDTO)
        {
            var quejas = new Quejas();
            quejas.Descripcion = insertQuejasDTO.Descripcion;
            quejas.IdUsuario = insertQuejasDTO.IdUsuario;
            quejas.Fecha = insertQuejasDTO.Fecha;

            var result = await _quejasRepository.Insert(quejas);
            return result;
        }

        public async Task<bool> Update(QuejasDTO quejasDTO)
        {
            var quejas = await _quejasRepository.GetID(quejasDTO.IdQuejas);
            if (quejas == null)
                return false;
            quejas.Descripcion = quejasDTO.Descripcion;
            quejas.IdUsuario = quejasDTO.IdUsuario;
            quejas.Fecha = quejasDTO.Fecha;
            var result = await _quejasRepository.Update(quejas);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var quejas = await _quejasRepository.GetID(id);
            if (quejas == null)
                return false;

            var result = await _quejasRepository.Delete(id);
            return result;
        }
    }
}
