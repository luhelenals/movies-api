using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using movies_api.dtos;

namespace movies_api.mappers
{
    public static class SessaoMapper
    {
        public static SessaoDTO ToSessaoDTO(this Sessao SessaoModel)
        {
            return new SessaoDTO
            {
                Id = SessaoModel.Id,
                Filme = SessaoModel.Filme,
                Horario = SessaoModel.Horario,
                Assentos = SessaoModel.Assentos
            };
        }

        public static Sessao ToSessaoModel(this SessaoDTO SessaoDTO)
        {
            return new Sessao
            {
                Filme = SessaoDTO.Filme,
                Horario = SessaoDTO.Horario,
                Assentos = SessaoDTO.Assentos
            };
        }
    }
}