using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.dtos;
using movies_api.models;
using movies_api.services;

namespace movies_api.mappers
{
    public class ReservaMapper(AssentoService assentoService, SessaoService sessaoService, UsuarioService usuarioService)
    {
        private readonly AssentoService _assentoService = assentoService;
        private readonly SessaoService _sessaoService = sessaoService;
        private readonly UsuarioService _usuarioService = usuarioService;

        public ReservaDTO ToReservaDTO(Reserva reserva)
        {
            List<int> assentos = reserva.Assentos.Select(a => a.Id).ToList();
            return new ReservaDTO
            {
                UsuarioId = reserva.UsuarioId,
                SessaoId = reserva.SessaoId,
                Assentos = assentos
            };
        }

        public async Task<Reserva> ToReserva(ReservaDTO dto)
        {
            var sessao = await _sessaoService.GetByIdAsync(dto.SessaoId);
            var usuario = await _usuarioService.GetByIdAsync(dto.UsuarioId);
            List<Assento> assentos = [];
            foreach (var id in dto.Assentos)
            {
                var assento = await _assentoService.GetByIdAsync(id);
                if (assento != null)
                {
                    assentos.Add(assento);
                }
            }

            return new Reserva
                {
                    UsuarioId = dto.UsuarioId,
                    SessaoId = dto.SessaoId,
                    Sessao = sessao,
                    Usuario = usuario,
                    Assentos = assentos
                };
        }
    }
}