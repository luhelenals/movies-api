using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.contracts;
using movies_api.models;
using movies_api.dtos;
using movies_api.mappers;

namespace movies_api.services
{
    public class UsuarioService(IUsuarioRepository repository)
    {
        private readonly IUsuarioRepository _repository = repository;

        public async Task<Usuario?> ExecuteAsync(UsuarioDTO dto)
        {
            // tratamento de erros:
            ArgumentNullException.ThrowIfNull(dto);

            string nome = dto.Nome.Trim();
            ArgumentNullException.ThrowIfNull(nome);

            if (nome.Contains(' '))
            {
                throw new ArgumentException("Nome de usuário não pode conter espaços");
            }

            // nome de usuário já cadastrado no banco
            if (await _repository.GetByNameAsync(nome) != null)
            {
                throw new ArgumentException("Usuário já existe");
            }

            return await _repository.CreateAsync(usuario: UsuarioMapper.ToUsuarioModel(dto));
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario?> GetByNameAsync(string nome)
        {
            // tratamento de erros:
            ArgumentNullException.ThrowIfNull(nome);

            return await _repository.GetByNameAsync(nome);
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await _repository.DeleteByIdAsync(id);
        }

        public async Task<Usuario?> UpdateByIdAsync(int id, UsuarioDTO dto)
        {
            Usuario usuario = UsuarioMapper.ToUsuarioModel(dto);
            return await _repository.UpdateByIdAsync(id, usuario);
        }
    }
}