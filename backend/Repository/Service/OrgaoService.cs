
﻿using GerenciamentoServidores.Data;
using GerenciamentoServidores.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Services
{
    public class OrgaoService : IOrgao
    {
        private readonly AppDbContext _context;

        public OrgaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servidor>> BuscarServidoresPorOrgao(int orgaoId)
        {
            return await _context.Servidores
                .Include(s => s.Orgao)  // Certifique-se de incluir a entidade 'Orgao'
                .Include(s => s.Lotacao) // Certifique-se de incluir a entidade 'Lotacao'
                .Where(s => s.OrgaoId == orgaoId)
                .ToListAsync();
        }
        public async Task<List<Orgao>> ListarOrgaos()
        {
            return await _context.Orgaos.ToListAsync();
        }


    }

}
