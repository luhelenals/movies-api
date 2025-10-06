using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.services;
using movies_api.dtos;

namespace movies_api.controllers
{
    [ApiController]
    [Route("/api/sala")]
    public class SalaController(SalaService service) : ControllerBase
    {
        private readonly SalaService _service = service;

        /// <summary>
        ///  Obtém uma sala pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="200">Retorna a sala com o ID especificado.</response>
        ///     <response code="404">Se a sala com o ID especificado não for encontrada.</response>
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sala = await _service.GetByIdAsync(id);
            if (sala is null)
                return NotFound();

            return Ok(sala);
        }

        /// <summary>
        ///   Cria uma nova sala.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="201">Retorna a sala recém-criada.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///    <response code="500">Se ocorrer um erro interno ao criar a sala.</response>
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SalaDTO dto)
        {
            try
            {
                var sala = await _service.CreateAsync(dto);
                if (sala == null)
                {
                    return BadRequest("Não foi possível criar a sala");
                }
                return CreatedAtAction(nameof(GetById), new { id = sala.Id }, sala);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao criar sala");
            }
        }

        /// <summary>
        ///   Deletar uma sala pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///     <response code="204">Se a sala foi excluída com sucesso.</response>
        ///     <response code="404">Se a sala com o ID especificado não for encontrada.</response>
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
        ///    Obtém todas as salas.
        /// </summary>
        /// <returns>
        ///     <response code="200">Retorna a lista de salas.</response>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var salas = await _service.GetAllAsync();
            return Ok(salas);
        }

        /// <summary>
        ///  Atualiza uma sala existente pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="200">Retorna a sala atualizada.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///     <response code="404">Se a sala com o ID especificado não for encontrada.</response>
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByIdAsync(int id, [FromBody] SalaDTO dto)
        {
            try
            {
                var sala = await _service.UpdateAsync(id, dto);
                if (sala is null)
                    return NotFound();

                return Ok(sala);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao atualizar sala");
            }
        }

    }
}