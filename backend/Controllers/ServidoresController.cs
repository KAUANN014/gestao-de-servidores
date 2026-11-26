
﻿using GerenciamentoServidores.DTOs;
using GerenciamentoServidores.Models;
using GerenciamentoServidores.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoServidores.Controllers
{
    [Route("api/servidores")]
    [ApiController]
    public class ServidorController : ControllerBase
    {
        private readonly IServidorService _servidorService;

        public ServidorController(IServidorService servidorService)
        {
            _servidorService = servidorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServidorDto>>> GetServidores()
        {
            var servidores = await _servidorService.ListarServidores();

            var servidoresDTO = servidores.Select(s => new ServidorDto
            {
                Id = s.Id,
                Nome = s.Nome,
                Telefone = s.Telefone,
                Email = s.Email,
                Orgao = s.Orgao.Nome,
                Lotacao = s.Lotacao.Nome,
                Sala = s.Sala,
                Status = s.Status
            }).ToList();

            return Ok(servidoresDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServidorDto>> GetServidor(int id)
        {
            var servidor = await _servidorService.BuscarPorId(id);

            if (servidor == null)
                return NotFound();

            var servidorDTO = new ServidorDto
            {
                Id = servidor.Id,
                Nome = servidor.Nome,
                Telefone = servidor.Telefone,
                Email = servidor.Email,
                Orgao = servidor.Orgao.Nome,
                Lotacao = servidor.Lotacao.Nome,
                Sala = servidor.Sala,
                Status = servidor.Status
            };

            return Ok(servidorDTO);
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<List<Servidor>>> BuscarServidores(
            [FromQuery] string nome,
            [FromQuery] int? orgaoId,
            [FromQuery] int? lotacaoId)
        {
            return await _servidorService.BuscarServidores(nome, orgaoId, lotacaoId);
        }


[HttpPost]
public async Task<ActionResult> PostServidor([FromBody] ServidorCreateDto servidorDto)
{
    if (!ModelState.IsValid)
    {
        var erros = ModelState.Values.SelectMany(v => v.Errors)
                                     .Select(e => e.ErrorMessage);
        return BadRequest(new { mensagem = "Erro de validação", erros });
    }

    var servidor = new Servidor
    {
        Nome = servidorDto.Nome,
        Telefone = servidorDto.Telefone,
        Email = servidorDto.Email,
        OrgaoId = servidorDto.OrgaoId,
        LotacaoId = servidorDto.LotacaoId,
        Sala = servidorDto.Sala,
        Status = servidorDto.Status ?? "Ativo"
    };

    var resultado = await _servidorService.CriarServidor(servidor);
    if (!resultado)
    {
        return BadRequest("Falha ao criar o servidor.");
    }

    return CreatedAtAction(nameof(GetServidor), new { id = servidor.Id }, servidor);
}


        [HttpPut("{id}")]
        public async Task<ActionResult> PutServidor(int id, [FromBody] ServidorUpdateDto servidorDto)
        {
            var servidorExistente = await _servidorService.BuscarPorId(id);
            if (servidorExistente == null) return NotFound();

            servidorExistente.Nome = servidorDto.Nome;
            servidorExistente.Telefone = servidorDto.Telefone;
            servidorExistente.Email = servidorDto.Email;
            servidorExistente.OrgaoId = servidorDto.OrgaoId;
            servidorExistente.LotacaoId = servidorDto.LotacaoId;
            servidorExistente.Sala = servidorDto.Sala;
            servidorExistente.Status = servidorDto.Status;

            var resultado = await _servidorService.AtualizarServidor(servidorExistente);
            if (!resultado) return BadRequest("Falha ao atualizar o servidor.");

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteServidor(int id)
        {
            var resultado = await _servidorService.InativarServidor(id);
            if (!resultado) return NotFound();
            return NoContent();
        }
    }
}
