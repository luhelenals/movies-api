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
        public static SessaoDTO ToSessaoDTO(this Sessao sessao)
        {
            var todosOsAssentosDaSala = sessao.Sala.Assentos;
            var assentosOcupados = sessao.Reservas.SelectMany(r => r.Assentos);
            var assentosDisponiveis = todosOsAssentosDaSala.Except(assentosOcupados, new AssentoIdComparer());

            return new SessaoDTO
            {
                Filme = sessao.Filme,
                HorarioInicio = sessao.HorarioInicio,
                HorarioFim = sessao.HorarioFim,
                SalaId = sessao.SalaId,
                AssentosDisponiveis = assentosDisponiveis.Count(),
                IdsAssentosDisponiveis = assentosDisponiveis.Select(a => a.Id).ToList()
            };
        }

        public static Sessao ToSessaoModel(this SessaoDTO SessaoDTO)
        {
            return new Sessao
            {
                Filme = SessaoDTO.Filme,
                HorarioInicio = SessaoDTO.HorarioInicio,
                HorarioFim = SessaoDTO.HorarioFim,
                SalaId = SessaoDTO.SalaId
            };
        }
    }

    public class AssentoIdComparer : IEqualityComparer<Assento>
    {
        public bool Equals(Assento? x, Assento? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(Assento obj)
        {
            ArgumentNullException.ThrowIfNull(obj);
            return obj.Id.GetHashCode();
        }
    }
}