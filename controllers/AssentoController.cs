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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assento = await _service.GetByIdAsync(id);
            if (assento is null)
                return NotFound();

            return Ok(assento);
        }

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
            var assentos = await _service.GetAllAsync();
            return Ok(assentos);
        }
    }
}