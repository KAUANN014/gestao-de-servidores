
﻿namespace GerenciamentoServidores.DTOs
{
    public class ServidorUpdateDto
    {
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public int OrgaoId { get; set; }
        public int LotacaoId { get; set; }
        public string? Sala { get; set; }
        public string Status { get; set; }
    }
}
