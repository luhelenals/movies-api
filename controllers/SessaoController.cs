using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.dtos;
using movies_api.services;
using movies_api.mappers;

namespace movies_api.controllers
{
    [ApiController]
    [Route("api/sessao")]
    public class SessaoController(SessaoService service) : ControllerBase
    {
        private readonly SessaoService _service = service;

        /// <summary>
        ///   Obtém todas as sessões.
        /// </summary>
        /// <returns>
        ///     <response code="200">Retorna a lista de sessões.</response>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sessoes = await _service.GetAllAsync();
            return Ok(sessoes.Select(s => SessaoMapper.ToSessaoDTO(s)));
        }

        /// <summary>
        ///  Obtém uma sessão pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="200">Retorna a sessão com o ID especificado.</response>
        ///     <response code="404">Se a sessão com o ID especificado não for
        /// </returns>
        [HttpGet("{id}", Name = "GetSessaoById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sessao = await _service.GetByIdAsync(id);
            if (sessao is null)
                return NotFound();

            return Ok(SessaoMapper.ToSessaoDTO(sessao));
        }

        /// <summary>
        ///  Cria uma nova sessão.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="201">Retorna a sessão recém-criada.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///   <response code="500">Se ocorrer um erro interno ao criar a sessão.</response>
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(SessaoDTO dto)
        {
            try
            {
                var sessao = await _service.CreateAsync(dto);
                if (sessao == null)
                {
                    return BadRequest("Não foi possível criar o usuário");
                }
                return CreatedAtRoute("GetSessaoById", new { id = sessao.Id }, sessao);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao criar sessão");
            }
        }

        /// <summary>
        /// Atualiza uma sessão existente pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="200">Retorna a sessão atualizada.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///     <response code="404">Se a sessão com o ID especificado não for encontrada.</response>
        ///     <response code="500">Se ocorrer um erro interno ao atualizar a sessão.</response>
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SessaoDTO dto)
        {
            try
            {
                var updatedSessao = await _service.UpdateAsync(id, dto);
                if (updatedSessao is null)
                    return NotFound();

                return Ok(updatedSessao);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao atualizar sessão");
            }
        }

        /// <summary>
        /// Exclui uma sessão pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="204">Se a sessão foi excluída com sucesso.</response>
        ///     <response code="404">Se a sessão com o ID especificado não for encontrada.</response>
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}