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
    public class UsuarioRepository(MoviesContext context) : IUsuarioRepository
    {
        private readonly MoviesContext _context = context;

        public async Task<Usuario?> CreateAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario?> GetByNameAsync(string nome)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Nome == nome);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario is null)
                return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}