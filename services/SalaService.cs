using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.mappers;
using movies_api.models;
using movies_api.contracts;
using movies_api.dtos;

namespace movies_api.services
{
    public class SalaService(ISalaRepository repository, SalaMapper mapper)
    {
        private readonly ISalaRepository _repository = repository;
        private readonly SalaMapper _mapper = mapper;

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Sala?> CreateAsync(SalaDTO dto)
        {
            Sala sala = await _mapper.ToSalaModel(dto);
            return await _repository.CreateAsync(sala);
        }

        public async Task<Sala?> UpdateAsync(int id, SalaDTO dto)
        {
            Sala sala = await _mapper.ToSalaModel(dto);
            return await _repository.UpdateByIdAsync(id, sala);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }
    }
}