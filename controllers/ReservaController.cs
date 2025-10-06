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
    [Route("api/reserva")]
    public class ReservaController(ReservaService service) : ControllerBase
    {
        private readonly ReservaService _service = service;

        /// <summary>
        /// Obtém uma reserva pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///   <response code="200">Retorna a reserva com o ID especificado.</response>
        ///  <response code="404">Se a reserva com o ID especificado não for encontrada.</response>
        /// </returns>
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reserva = await _service.GetByIdAsync(id);
            if (reserva is null)
                return NotFound();

            return Ok(reserva);
        }

        /// <summary>
        /// Cria uma nova reserva de assentos.
        /// </summary>
        /// <param name="dto">Dados da reserva a ser criada.</param>
        /// <response code="201">Retorna a reserva recém-criada.</response>
        /// <response code="400">Se um dos assentos já estiver ocupado ou os dados forem inválidos.</response>
        /// <response code="500">Se ocorrer um erro interno ao criar a reserva.</response>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ReservaDTO dto)
        {
            try
            {
                var reserva = await _service.CreateAsync(dto);
                if (reserva == null)
                {
                    return BadRequest("Não foi possível criar a reserva");
                }
                return CreatedAtAction("GetById", new { id = reserva.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao criar reserva");
            }
        }
        
        /// <summary>
        /// Exclui uma reserva pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// <response code="204">Se a reserva foi excluída com sucesso.</response>
        /// <response code="404">Se a reserva com o ID especificado não for encontrada.</response>
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
        /// Obtém todas as reservas.
        /// </summary>
        /// <returns>
        /// <response code="200">Retorna a lista de reservas.</response>
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var reservas = await _service.GetAllAsync();
            return Ok(reservas);
        }

        /// <summary>
        /// Atualiza uma reserva existente pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns>
        ///     <response code="200">Retorna a reserva atualizada.</response>
        ///     <response code="400">Se os dados forem inválidos.</response>
        ///     <response code="404">Se a reserva com o ID especificado não for encontrada.</response>
        /// </returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ReservaDTO dto)
        {
            try
            {
                var reserva = await _service.UpdateByIdAsync(id, dto);
                if (reserva is null)
                    return NotFound();

                return Ok(dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro interno ao atualizar reserva");
            }
        }

        /// <summary>
        /// Obtém todas as reservas feitas por um usuário específico.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns>
        ///     <response code="200">Retorna a lista de reservas do usuário.</response>
        /// </returns>
        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetReservasByUsuario([FromRoute] int usuarioId)
        {
            var reservas = await _service.GetReservasByUsuario(usuarioId);
            return Ok(reservas);
        }
    }
}