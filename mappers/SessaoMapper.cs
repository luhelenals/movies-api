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
                Filme = SessaoModel.Filme,
                HorarioInicio = SessaoModel.HorarioInicio,
                HorarioFim = SessaoModel.HorarioFim,
                SalaId = SessaoModel.SalaId
            };
        }

        public static Sessao ToSessaoModel(this SessaoDTO SessaoDTO)
        {
            return new Sessao
            {
                Filme = SessaoDTO.Filme,
                HorarioInicio = SessaoDTO.HorarioInicio,
                HorarioFim = SessaoDTO.HorarioFim,
                SalaId = SessaoDTO.SalaId,
                Sala = null // provisório, add repositório depois
            };
        }
    }
}