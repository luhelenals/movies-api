using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using movies_api.contracts;
using movies_api.dtos;
using movies_api.mappers;

namespace movies_api.services
{
    public class ReservaService(IReservaRepository repository, ReservaMapper mapper)
    {
        private readonly IReservaRepository _repository = repository;
        private readonly ReservaMapper _mapper = mapper;

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Reserva?> CreateAsync(ReservaDTO dto)
        {
            Reserva reserva = await _mapper.ToReserva(dto);
            return await _repository.CreateAsync(reserva);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<Reserva?> UpdateByIdAsync(int id, ReservaDTO dto)
        {
            Reserva reserva = await _mapper.ToReserva(dto);
            return await _repository.UpdateByIdAsync(id, reserva);
        }
    }
}