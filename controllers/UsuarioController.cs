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
            var usuario = await _service.ExecuteAsync(dto);
            if(usuario == null)
            {
                return BadRequest("Não foi possível criar o usuário");
            }
            return CreatedAtAction(nameof(GetByIdAsync), new { id = usuario.Id }, usuario);
        }

        [HttpGet("{id}")]
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
    }
}