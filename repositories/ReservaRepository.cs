using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.data;
using movies_api.models;
using Microsoft.EntityFrameworkCore;

namespace movies_api.repositories
{
    public class ReservaRepository(MoviesContext context) : IReservaRepository
    {
        private readonly MoviesContext _context = context;

        public async Task<List<Reserva>> GetAllAsync()
        {
            return await _context.Reservas.AsNoTracking().ToListAsync();
        }

        public async Task<Reserva?> GetByIdAsync(int id)
        {
            var reserva = await _context.Reservas.FirstOrDefaultAsync(r => r.Id == id);
            return reserva;
        }

        public async Task<Reserva?> CreateAsync(Reserva reserva)
        {
            foreach (var assento in reserva.Assentos)
            {
                _context.Attach(assento);
            }

            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva is null)
                return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reserva?> UpdateByIdAsync(int id, Reserva reserva)
        {
            var oldReserva = await _context.Reservas
                                   .Include(r => r.Assentos)
                                   .FirstOrDefaultAsync(r => r.Id == id);
            if (oldReserva is null)
                return null;

            oldReserva.DataReserva = reserva.DataReserva;
            oldReserva.UsuarioId = reserva.UsuarioId;
            oldReserva.SessaoId = reserva.SessaoId;

            oldReserva.Assentos.Clear();
            foreach (var assento in reserva.Assentos)
            {
                oldReserva.Assentos.Add(assento);
            }

            await _context.SaveChangesAsync();

            return oldReserva;
        }

        public async Task<List<Reserva>> GetReservasByUsuario(int usuarioId)
        {
            return await _context.Reservas.Where(r => r.UsuarioId == usuarioId).ToListAsync();
        }

    }
}