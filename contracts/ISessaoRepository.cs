using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.contracts
{
    public interface ISessaoRepository
    {
        Task<Sessao?> GetByIdAsync(int id);
        Task<List<Sessao>> GetAllAsync();
        Task<Sessao?> CreateAsync(Sessao sessao);
        Task<bool> DeleteByIdAsync(int id);
        Task<Sessao?> UpdateByIdAsync(int id, Sessao sessao);
        Task<List<Sessao>> GetSessoesBySalaIdAsync(int salaId);
    }
}