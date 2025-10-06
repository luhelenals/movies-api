using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.dtos;
using movies_api.models;
using movies_api.mappers;

namespace movies_api.services
{
    public class AssentoService(IAssentoRepository repository, AssentoMapper mapper)
    {
        private readonly AssentoMapper _mapper = mapper;
        private readonly IAssentoRepository _repository = repository;

        public async Task<Assento?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Assento?> CreateAsync(AssentoDTO dto)
        {
            Assento assento = await _mapper.ToAssento(dto);
            var response = await _repository.CreateAsync(assento);
            return response;
        }

        public async Task<List<Assento>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}