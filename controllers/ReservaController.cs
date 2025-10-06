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

        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var reserva = await _service.GetByIdAsync(id);
            if (reserva is null)
                return NotFound();

            return Ok(reserva);
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var deleted = await _service.DeleteByIdAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var reservas = await _service.GetAllAsync();
            return Ok(reservas);
        }

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

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetReservasByUsuario([FromRoute] int usuarioId)
        {
            var reservas = await _service.GetReservasByUsuario(usuarioId);
            return Ok(reservas);
        }
    }
}