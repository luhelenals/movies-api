using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.dtos;
using movies_api.models;

namespace movies_api.mappers
{
    public static class AssentoMapper
    {
        public static AssentoDTO ToAssentoDTO(Assento assento)
        {
            return new AssentoDTO
            {
                SalaId = assento.SalaId
            };
        }

        public static Assento ToAssento(AssentoDTO dto)
        {
            return new Assento
            {
                Reservas = [],
                SalaId = dto.SalaId,
                Sala = null
            };
        }
    }
}