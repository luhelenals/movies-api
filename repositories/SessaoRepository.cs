using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.models;
using movies_api.data;
using Microsoft.EntityFrameworkCore;

namespace movies_api.repositories
{
    public class SessaoRepository(MoviesContext context) : ISessaoRepository
    {
        private readonly MoviesContext _context = context;

        public async Task<List<Sessao>> GetAllAsync()
        {
            return await _context.Sessoes.AsNoTracking()
                                 .Include(s => s.Sala)
                                 .ThenInclude(sala => sala.Assentos)
                                 .Include(s => s.Reservas)
                                 .ThenInclude(reserva => reserva.Assentos)
                                 .ToListAsync();
        }

        public async Task<Sessao?> CreateAsync(Sessao sessao)
        {
            await _context.Sessoes.AddAsync(sessao);
            await _context.SaveChangesAsync();
            return sessao;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var sessao = await _context.Sessoes.FindAsync(id);
            if (sessao is null)
                return false;

            _context.Sessoes.Remove(sessao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Sessao?> UpdateByIdAsync(int id, Sessao sessao)
        {
            var oldSessao = await _context.Sessoes.FindAsync(id);
            if (oldSessao is null)
                return null;

            oldSessao.Filme = sessao.Filme;
            oldSessao.HorarioInicio = sessao.HorarioInicio;
            oldSessao.HorarioFim = sessao.HorarioFim;
            oldSessao.SalaId = sessao.SalaId;
            oldSessao.Sala = sessao.Sala;

            await _context.SaveChangesAsync();

            return oldSessao;
        }

        public async Task<List<Sessao>> GetSessoesBySalaIdAsync(int salaId)
        {
            return await _context.Sessoes.AsNoTracking().Where(s => s.SalaId == salaId).ToListAsync();
        }

        public async Task<Sessao?> GetByIdAsync(int id)
        {
            return await _context.Sessoes
                .AsNoTracking()
                .Include(s => s.Sala)
                .ThenInclude(sala => sala.Assentos)
                .Include(s => s.Reservas)
                .ThenInclude(reserva => reserva.Assentos)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}