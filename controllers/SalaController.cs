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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sala = await _service.GetByIdAsync(id);
            if (sala is null)
                return NotFound();

            return Ok(sala);
        }

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
            var salas = await _service.GetAllAsync();
            return Ok(salas);
        }

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