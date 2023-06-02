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
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public async Task<IEnumerable<TipoUsuarioDTO>> GetAll()
        {
            var tipousuarios = await _tipoUsuarioRepository.GetAll();
            var tipousuariosDTO = new List<TipoUsuarioDTO>();

            foreach (var tipoUsuario in tipousuarios)
            {
                var tipUsuarioDTO = new TipoUsuarioDTO();
                tipUsuarioDTO.IdTipo = tipoUsuario.IdTipo;
                tipUsuarioDTO.Descripcion = tipoUsuario.Descripcion;

                tipousuariosDTO.Add(tipUsuarioDTO);
            }
            return tipousuariosDTO;
        }
        public async Task<TipoUsuarioDTO> GetById(int id)
        {
            var tipousuario = await _tipoUsuarioRepository.GetById(id);
            if (tipousuario == null)
                return null;

            var tipousuarioDTO = new TipoUsuarioDTO()
            {
                IdTipo = tipousuario.IdTipo,
                Descripcion = tipousuario?.Descripcion,
            };
            return tipousuarioDTO;
        }

        public async Task<bool> Insert(InsertTipoUsuarioDTO insertipoUsuarioDTO)
        {
            var tipousuario = new TipoUsuario();
            tipousuario.Descripcion = insertipoUsuarioDTO.Descripcion;

            var result = await _tipoUsuarioRepository.Insert(tipousuario);
            return result;
        }

        public async Task<bool> Update(TipoUsuarioDTO tipoUsuarioDTO)
        {
            var tipousuario = await _tipoUsuarioRepository.GetById(tipoUsuarioDTO.IdTipo);
            if (tipousuario == null)
                return false;
            tipousuario.Descripcion = tipousuario.Descripcion;

            var result = await _tipoUsuarioRepository.Update(tipousuario);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var tipoUsuario = await _tipoUsuarioRepository.GetById(id);
            if (tipoUsuario == null)
                return false;
            var result = await _tipoUsuarioRepository.Delete(id);
            return result;
        }

        public Task<bool> Insert(TipoUsuarioDTO tipoUsuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
