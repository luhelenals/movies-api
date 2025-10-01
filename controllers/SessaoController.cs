using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movies_api.data;
using movies_api.models;
using movies_api.dtos;
using movies_api.mappers;

namespace movies_api.controllers
{
    [ApiController]
    [Route("api/sessao")]
    public class SessaoController : ControllerBase
    {
        private readonly MoviesContext _context;

        public SessaoController(MoviesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSessoes()
        {
            var sessoes = _context.Sessoes.ToList();
            var sessoesDTO = sessoes.Select(s => s.ToSessaoDTO()).ToList();
            return Ok(sessoesDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetSessaoById(int id)
        {
            var sessao = _context.Sessoes.Find(id);
            if (sessao == null)
            {
                return NotFound();
            }
            return Ok(sessao.ToSessaoDTO());
        }

        [HttpPost]
        public IActionResult CreateSessao([FromBody] SessaoDTO newSessao)
        {
            Sessao sessao = newSessao.ToSessaoModel();
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessoes), new { id = sessao.Id }, newSessao);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            var sessao = _context.Sessoes.Find(id);
            if (sessao == null)
            {
                return NotFound();
            }

            _context.Sessoes.Remove(sessao);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSessao(int id, [FromBody] SessaoDTO updatedSessao)
        {
            var existingSessao = _context.Sessoes.Find(id);
            if (existingSessao == null)
            {
                return NotFound();
            }

            existingSessao.Filme = updatedSessao.Filme;
            existingSessao.Horario = updatedSessao.Horario;
            existingSessao.Assentos = updatedSessao.Assentos;
            _context.SaveChanges();
            return NoContent();
        }
    }
}