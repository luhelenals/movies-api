using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.models;
using movies_api.mappers;
using movies_api.dtos;

namespace movies_api.services
{
    public class SessaoService(ISessaoRepository repository)
    {
        private readonly ISessaoRepository _repository = repository;

        public async Task<Sessao?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Sessao>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Sessao?> CreateAsync(SessaoDTO dto)
        {
            Sessao sessao = SessaoMapper.ToSessaoModel(dto);

            // verifica horários válidos
            if (sessao.HorarioFim <= sessao.HorarioInicio)
            {
                throw new ArgumentException("O horário de fim deve ser maior que o horário de início.");
            }

            // validação de horários conflitantes na mesma sala
            var sessoesSala = await _repository.GetSessoesBySalaIdAsync(sessao.SalaId);
            if (sessoesSala.Any(s => s.HorarioInicio < sessao.HorarioFim && sessao.HorarioInicio < s.HorarioFim))
            {
                throw new ArgumentException("Conflito de horário com outra sessão na mesma sala.");
            }

            var response = await _repository.CreateAsync(sessao);
            return response;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<Sessao?> UpdateAsync(int id, SessaoDTO dto)
        {
            Sessao sessao = SessaoMapper.ToSessaoModel(dto);
            return await _repository.UpdateByIdAsync(id, sessao);
        }
    }
}