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

        [HttpPost]
        public IActionResult CreateSessao([FromBody] SessaoDTO newSessao)
        {
            Sessao sessao = newSessao.ToSessaoModel();
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetSessoes), new { id = sessao.Id }, newSessao);
        }

    }
}