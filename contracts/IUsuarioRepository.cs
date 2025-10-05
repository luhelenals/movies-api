using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using movies_api.dtos;

namespace movies_api.contracts
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByNameAsync(string nome);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> CreateAsync(Usuario usuario);
        Task<bool> DeleteByIdAsync(int id);
        Task<Usuario?> UpdateByIdAsync(int id, Usuario usuario);
    }
}