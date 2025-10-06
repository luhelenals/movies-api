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
            var reserva = await _context.Reservas.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return reserva;
        }

        public async Task<Reserva?> CreateAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var reserva = await GetByIdAsync(id);
            if (reserva is null)
                return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reserva?> UpdateByIdAsync(int id, Reserva reserva)
        {
            var oldReserva = await GetByIdAsync(id);
            if (oldReserva is null)
                return null;

            oldReserva.DataReserva = reserva.DataReserva;
            oldReserva.Assentos = reserva.Assentos;
            oldReserva.UsuarioId = reserva.UsuarioId;
            oldReserva.Usuario = reserva.Usuario;
            oldReserva.SessaoId = reserva.SessaoId;
            oldReserva.Sessao = reserva.Sessao;

            await _context.SaveChangesAsync();

            return oldReserva;
        }

    }
}