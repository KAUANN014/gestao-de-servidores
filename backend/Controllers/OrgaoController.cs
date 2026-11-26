
﻿using GerenciamentoServidores.DTOs;
using GerenciamentoServidores.Models;
using GerenciamentoServidores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Controllers
{
    [ApiController]
    [Route("api/orgaos")]
    public class OrgaoController : ControllerBase
    {
        private readonly IOrgao _orgaoService;

        public OrgaoController(IOrgao orgaoService)
        {
            _orgaoService = orgaoService;
        }

        [HttpGet("por-orgao/{orgaoId}")]
        public async Task<ActionResult<List<ServidorDto>>> GetServidoresPorOrgao(int orgaoId)
        {
            try
            {
                var servidores = await _orgaoService.BuscarServidoresPorOrgao(orgaoId);

                if (servidores == null || servidores.Count == 0)
                    return NotFound("Nenhum servidor encontrado para este órgão.");

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
            catch (Exception ex)
            {
                // Logando a exceção (se necessário, usar ILogger para uma log mais robusto)
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpGet] // Novo endpoint para listar órgãos
        public async Task<ActionResult<List<Orgao>>> GetOrgaos()
        {
            try
            {
                var orgaos = await _orgaoService.ListarOrgaos();
                return Ok(orgaos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

    }

}
