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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = await _service.GetAllAsync();
            return Ok(usuarios);
        }

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
    }
}