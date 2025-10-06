using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.dtos;
using movies_api.services;

namespace movies_api.controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController(UsuarioService service) : ControllerBase
    {
        private readonly UsuarioService _service = service;

        /// <summary>
        ///     Cria um novo usuário.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="201">Retorna o usuário recém-criado.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///   <response code="500">Se ocorrer um erro interno ao criar o usuário.</response>
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UsuarioDTO dto)
        {
            try
            {
                var usuario = await _service.ExecuteAsync(dto);
                if (usuario == null)
                {
                    return BadRequest("Não foi possível criar o usuário");
                }
                return CreatedAtRoute("GetUsuarioById", new { id = usuario.Id }, usuario);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao criar usuário");
            }
        }

        /// <summary>
        ///     Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="200">Retorna o usuário com o ID especificado.</response>
        ///     <response code="404">Se o usuário com o ID especificado não for encontrado.</response>
        /// </returns>
        [HttpGet("{id}", Name = "GetUsuarioById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        ///   Obtém um usuário pelo nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>
        ///     <response code="200">Retorna o usuário com o nome especificado.</response>
        ///     <response code="404">Se o usuário com o nome especificado não for encontrado.</response>
        /// </returns>
        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNameAsync(string nome)
        {
            var usuario = await _service.GetByNameAsync(nome);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        ///  Obtém todos os usuários.
        /// </summary>
        /// <returns>
        ///     <response code="200">Retorna a lista de usuários.</response>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

        /// <summary>
        ///  Deleta um usuário pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="204">Se o usuário foi excluído com sucesso.</response>
        ///     <response code="404">Se o usuário com o ID especificado não for encontrado.</response>
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool deleted = await _service.DeleteByIdAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        /// <summary>
        ///  Atualiza um usuário existente pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="200">Retorna o usuário atualizado.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UsuarioDTO dto)
        {
            var usuario = await _service.UpdateByIdAsync(id, dto);

            if (usuario is null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }
    }
}