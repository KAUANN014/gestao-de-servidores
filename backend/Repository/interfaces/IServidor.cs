
﻿using GerenciamentoServidores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Services
{
    public interface IServidorService
    {
      
        Task<List<Servidor>> BuscarServidores(string nome, int? orgaoId, int? lotacaoId);
        Task<List<Servidor>> ListarServidores();
        Task<Servidor> BuscarPorId(int id);
        Task<bool> CriarServidor(Servidor servidor);
        Task<bool> AtualizarServidor(Servidor servidor);
        Task<bool> InativarServidor(int id);
  
    }
}
