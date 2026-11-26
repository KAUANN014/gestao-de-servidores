
﻿using GerenciamentoServidores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoServidores.Services
{
    public interface IOrgao
    {
        Task<List<Servidor>> BuscarServidoresPorOrgao(int orgaoId);
        Task<List<Orgao>> ListarOrgaos();

    }

}
