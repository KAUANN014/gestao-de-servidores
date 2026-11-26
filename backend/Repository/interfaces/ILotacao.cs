
﻿using GerenciamentoServidores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Services
{
    public interface ILotacao
    {
        Task<List<Servidor>> BuscarServidoresPorLotacao(int lotacaoId);
        Task<List<Lotacao>> ListarLotacoes();
        Task<List<Lotacao>> ListarLotacoesPorOrgao(int orgaoId);

    }
}
