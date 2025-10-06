using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.contracts
{
    public interface IAssentoRepository
    {
        Task<Assento?> GetByIdAsync(int id);
        Task<List<Assento>> GetAllAsync();
        Task<Assento?> CreateAsync(Assento assento);
        Task<bool> DeleteAsync(int id);
    }
}