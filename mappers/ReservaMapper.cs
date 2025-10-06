using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.dtos;
using movies_api.models;
using movies_api.services;

namespace movies_api.mappers
{
    public class ReservaMapper
    {
        public static ReservaDTO ToReservaDTO(Reserva reserva)
        {
            List<int> assentos = reserva.Assentos.Select(a => a.Id).ToList();
            return new ReservaDTO
            {
                UsuarioId = reserva.UsuarioId,
                SessaoId = reserva.SessaoId,
                Assentos = assentos
            };
        }

        public static Reserva ToReserva(ReservaDTO dto)
        {
            var assentosParaVincular = dto.Assentos.Select(assentoId => new Assento { Id = assentoId }).ToList();

            return new Reserva
                {
                    UsuarioId = dto.UsuarioId,
                    SessaoId = dto.SessaoId,
                    Assentos = assentosParaVincular
                };
        }
    }
}