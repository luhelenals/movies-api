using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using movies_api.dtos;

namespace movies_api.mappers
{
    public class UsuarioMapper
    {
        public static UsuarioDTO ToUsuarioDTO(Usuario usuarioModel)
        {
            return new UsuarioDTO
            {
                Nome = usuarioModel.Nome,
                Reservas = usuarioModel.Reservas
            };
        }

        public static Usuario ToUsuarioModel(UsuarioDTO dto)
        {
            return new Usuario
            {
                Nome = dto.Nome,
                Reservas = dto.Reservas ?? []
            };
        }
    }
}