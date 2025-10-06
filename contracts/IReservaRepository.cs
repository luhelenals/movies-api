using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.contracts
{
    public interface IReservaRepository
    {
        Task<Reserva?> GetByIdAsync(int id);
        Task<List<Reserva>> GetAllAsync();
        Task<Reserva?> CreateAsync(Reserva reserva);
        Task<bool> DeleteByIdAsync(int id);
        Task<Reserva?> UpdateByIdAsync(int id, Reserva reserva);
    }
}