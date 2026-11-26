
﻿using GerenciamentoServidores.Data;
using GerenciamentoServidores.Models;
using Microsoft.EntityFrameworkCore;


namespace GerenciamentoServidores.Services
{
    public class ServidorService : IServidorService
    {
        private readonly AppDbContext _context;

        public ServidorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Servidor>> ListarServidores()
        {
            return await _context.Servidores
                .Include(s => s.Orgao)
                .Include(s => s.Lotacao)
                .ToListAsync();
        }

        public async Task<Servidor> BuscarPorId(int id)
        {
            return await _context.Servidores
                .Include(s => s.Orgao)
                .Include(s => s.Lotacao)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> CriarServidor(Servidor servidor)
        {
            try
            {
                // Supondo que você esteja usando Entity Framework:
                await _context.Servidores.AddAsync(servidor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Log de erro aqui
                return false;
            }
        }


        public async Task<bool> AtualizarServidor(Servidor servidor)
        {
            _context.Servidores.Update(servidor);
            var resultado = await _context.SaveChangesAsync();
            return resultado > 0; // Retorna true se a atualização foi bem-sucedida
        }


        public async Task<bool> InativarServidor(int id)
        {
            var servidor = await _context.Servidores.FindAsync(id);
            if (servidor == null)
            {
                return false;
            }

            servidor.Status = "Inativo";

            _context.Entry(servidor).State = EntityState.Modified;

            int changes = await _context.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<List<Servidor>> BuscarServidores(string nome, int? orgaoId, int? lotacaoId)
        {
            var query = _context.Servidores
                .Include(s => s.Orgao)
                .Include(s => s.Lotacao)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(s => s.Nome.Contains(nome));

            if (orgaoId.HasValue)
                query = query.Where(s => s.OrgaoId == orgaoId.Value);

            if (lotacaoId.HasValue)
                query = query.Where(s => s.LotacaoId == lotacaoId.Value);

            return await query.ToListAsync();
        }


    }
}
