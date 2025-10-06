using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.dtos;
using movies_api.models;
using movies_api.services;

namespace movies_api.mappers
{
    public class AssentoMapper(SalaService service)
    {
        private readonly SalaService _service = service;
        public static AssentoDTO ToAssentoDTO(Assento assento)
        {
            return new AssentoDTO
            {
                SalaId = assento.SalaId
            };
        }

        public async Task<Assento> ToAssento(AssentoDTO dto)
        {
            return new Assento
            {
                Reservas = [],
                SalaId = dto.SalaId,
                Sala = await _service.GetByIdAsync(dto.SalaId) ?? throw new Exception("Sala not found")
            };
        }
    }
}