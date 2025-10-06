using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using movies_api.contracts;
using movies_api.data;
using Microsoft.EntityFrameworkCore;

namespace movies_api.repositories
{
    public class SalaRepository(MoviesContext context) : ISalaRepository
    {
        private readonly MoviesContext _context = context;

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _context.Salas.AsNoTracking().ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(int id)
        {
            var sala = await _context.Salas.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
            return sala;
        }

        public async Task<Sala?> CreateAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var sala = await GetByIdAsync(id);
            if (sala is null)
                return false;

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Sala?> UpdateByIdAsync(int id, Sala sala)
        {
            var oldSala = await _context.Salas.FindAsync(id);
            if (oldSala is null)
                return null;

            oldSala.Nome = sala.Nome;
            oldSala.Capacidade = sala.Capacidade;
            oldSala.Assentos = sala.Assentos;
            oldSala.Sessoes = sala.Sessoes;

            await _context.SaveChangesAsync();

            return oldSala;
        }
    }
}