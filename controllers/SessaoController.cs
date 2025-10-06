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

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sessoes = await _service.GetAllAsync();
            return Ok(sessoes.Select(s => SessaoMapper.ToSessaoDTO(s)));
        }

        [HttpGet("{id}", Name = "GetSessaoById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sessao = await _service.GetByIdAsync(id);
            if (sessao is null)
                return NotFound();

            return Ok(SessaoMapper.ToSessaoDTO(sessao));
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