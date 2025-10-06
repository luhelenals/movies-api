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
    [Route("api/sessao")]
    public class SessaoController(SessaoService service) : ControllerBase
    {
        private readonly SessaoService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sessoes = await _service.GetAllAsync();
            return Ok(sessoes);
        }

        [HttpGet("{id}", Name = "GetSessaoById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sessao = await _service.GetByIdAsync(id);
            if (sessao is null)
                return NotFound();

            return Ok(sessao);
        }

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
    }
}