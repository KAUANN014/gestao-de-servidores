
﻿using Microsoft.EntityFrameworkCore;
using GerenciamentoServidores.Models;

namespace GerenciamentoServidores.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Servidor> Servidores { get; set; }
        public DbSet<Orgao> Orgaos { get; set; }
        public DbSet<Lotacao> Lotacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servidor>()
                .HasOne(s => s.Orgao)
                .WithMany()
                .HasForeignKey(s => s.OrgaoId);

            modelBuilder.Entity<Servidor>()
                .HasOne(s => s.Lotacao)
                .WithMany()
                .HasForeignKey(s => s.LotacaoId);

            modelBuilder.Entity<Lotacao>()
                .HasOne(l => l.Orgao)
                .WithMany()
                .HasForeignKey(l => l.OrgaoId);
        }
    }
}
