using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.contracts
{
    public interface ISalaRepository
    {
        Task<Sala?> GetByIdAsync(int id);
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> CreateAsync(Sala sala);
        Task<bool> DeleteByIdAsync(int id);
        Task<Sala?> UpdateByIdAsync(int id, Sala sala);
    }
}