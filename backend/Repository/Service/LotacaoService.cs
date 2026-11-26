
﻿using GerenciamentoServidores.Data;
using GerenciamentoServidores.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Services
{
    public class LotacaoService : ILotacao
    {
        private readonly AppDbContext _context;

        public LotacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servidor>> BuscarServidoresPorLotacao(int lotacaoId)
        {
            return await _context.Servidores
                .Include(s => s.Orgao)    // Inclui o órgão
                .Include(s => s.Lotacao)  // Inclui a lotação
                .Where(s => s.LotacaoId == lotacaoId)  // Filtra pela lotação
                .ToListAsync();
        }
        public async Task<List<Lotacao>> ListarLotacoes()
        {
            return await _context.Lotacoes
                .Include(l => l.Orgao)  // Incluindo o 'Orgao' associado à lotação
                .ToListAsync();  // Retorna todas as lotações com seus respectivos órgãos
        }
        public async Task<List<Lotacao>> ListarLotacoesPorOrgao(int orgaoId)
        {
            return await _context.Lotacoes
                .Where(l => l.OrgaoId == orgaoId)  // Filtra as lotações pelo id do órgão
                .Include(l => l.Orgao)  // Inclui o órgão na lotação
                .ToListAsync();
        }

      
    }
}
