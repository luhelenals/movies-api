using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movies_api.contracts;
using movies_api.data;
using movies_api.models;

namespace movies_api.repositories
{
    public class AssentoRepository(MoviesContext context) : IAssentoRepository
    {
        private readonly MoviesContext _context = context;

        public async Task<Assento?> GetByIdAsync(int id)
        {
            return await _context.Assentos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Assento?> CreateAsync(Assento assento)
        {
            await _context.Assentos.AddAsync(assento);
            await _context.SaveChangesAsync();

            return assento;
        }

        public async Task<List<Assento>> GetAllAsync()
        {
            var assentos = await _context.Assentos.ToListAsync();
            return assentos;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var assento = await GetByIdAsync(id);
            if (assento is null)
                return false;

            _context.Remove(assento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}