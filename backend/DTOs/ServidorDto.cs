
﻿namespace GerenciamentoServidores.DTOs
{
    public record ServidorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string Orgao { get; set; }
        public string Lotacao { get; set; }
        public string? Sala { get; set; }
        public string Status { get; set; }
    }
}
