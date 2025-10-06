using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.services;
using movies_api.dtos;
using Microsoft.AspNetCore.Mvc;

namespace movies_api.controllers
{
    [ApiController]
    [Route("/api/assento")]
    public class AssentoController(AssentoService service) : ControllerBase
    {
        private readonly AssentoService _service = service;

        /// <summary>
        /// Obtém um assento pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="200">Retorna o assento com o ID especificado.</response>
        ///     <response code="404">Se o assento com o ID especificado não for encontrado.</response>
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assento = await _service.GetByIdAsync(id);
            if (assento is null)
                return NotFound();

            return Ok(assento);
        }

        /// <summary>
        /// Cria um novo assento.
        /// </summary>
        /// <param name="dto">Dados do assento a ser criado.</param>
        /// <returns>
        ///     <response code="201">Retorna o assento recém-criado.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///     <response code="500">Se ocorrer um erro interno ao criar o assento.</response>
        /// <returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssentoDTO dto)
        {
            try
            {
                var assento = await _service.CreateAsync(dto);
                if (assento == null)
                {
                    return BadRequest("Não foi possível criar o assento");
                }
                return CreatedAtAction(nameof(GetById), new { id = assento.Id }, assento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao criar assento");
            }
        }

        /// <summary>
        ///     Deletar um assento pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="204">Se o assento foi excluído com sucesso.</response>
        ///     <response code="404">Se o assento com o ID especificado não for encontrado.</response>
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        ///   Obtém todos os assentos.
        /// </summary>
        /// <returns>
        ///    <response code="200">Retorna a lista de assentos.</response>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var assentos = await _service.GetAllAsync();
            return Ok(assentos);
        }
    }
}