
﻿using GerenciamentoServidores.DTOs;
using GerenciamentoServidores.Models;
using GerenciamentoServidores.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Controllers
{
    [ApiController]
    [Route("api/lotacoes")]
    public class LotacaoController : ControllerBase
    {
        private readonly ILotacao _lotacaoService;

        public LotacaoController(ILotacao lotacaoService)
        {
            _lotacaoService = lotacaoService;
        }

        [HttpGet("por-lotacao/{lotacaoId}")]
        public async Task<ActionResult<List<ServidorDto>>> GetServidoresPorLotacao(int lotacaoId)
        {
            try
            {
                var servidores = await _lotacaoService.BuscarServidoresPorLotacao(lotacaoId);

                if (servidores == null || servidores.Count == 0)
                    return NotFound("Nenhum servidor encontrado para esta lotação.");

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
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }

        }
        [HttpGet]
        public async Task<ActionResult<List<Lotacao>>> GetAllLotacoes()
        {
            try
            {
                var lotacoes = await _lotacaoService.ListarLotacoes();
                return Ok(lotacoes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpGet("por-orgao/{orgaoId}")]
        public async Task<ActionResult<List<Lotacao>>> GetLotacoesPorOrgao(int orgaoId)
        {
            try
            {
                var lotacoes = await _lotacaoService.ListarLotacoesPorOrgao(orgaoId);

                if (lotacoes == null || lotacoes.Count == 0)
                    return NotFound("Nenhuma lotação encontrada para este órgão.");

                return Ok(lotacoes);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


    }
}
