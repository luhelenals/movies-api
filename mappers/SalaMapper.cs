using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.dtos;
using movies_api.models;

namespace movies_api.mappers
{
    public class SalaMapper(ISessaoRepository sessaoRepository, IAssentoRepository assentoRepository)
    {
        private readonly ISessaoRepository _sessaoRepository = sessaoRepository;
        private readonly IAssentoRepository _assentoRepository = assentoRepository;
        
        public static SalaDTO ToSalaDTO(Sala SalaModel)
        {
            var assentoIds = SalaModel.Assentos?.Select(a => a.Id).ToList();
            var sessaoIds = SalaModel.Sessoes?.Select(s => s.Id).ToList();

            return new SalaDTO
            {
                Nome = SalaModel.Nome,
                Capacidade = SalaModel.Capacidade,
                Assentos = assentoIds ?? [],
                Sessoes = sessaoIds ?? []
            };
        }

        public async Task<Sala> ToSalaModel(SalaDTO SalaDTO)
        {
            var assentos = new List<Assento>();
            foreach (var id in SalaDTO.Assentos)
            {
                var assento = await _assentoRepository.GetByIdAsync(id);
                if (assento is not null)
                    assentos.Add(assento);
            }

            var sessoes = new List<Sessao>();
            foreach (var id in SalaDTO.Sessoes)
            {
                var sessao = await _sessaoRepository.GetByIdAsync(id);
                if (sessao is not null)
                    sessoes.Add(sessao);
            }

            return new Sala
            {
                Nome = SalaDTO.Nome,
                Capacidade = SalaDTO.Capacidade,
                Assentos = assentos,
                Sessoes = sessoes
            };
        }
    }
}