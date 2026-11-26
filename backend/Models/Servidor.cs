
﻿using System.ComponentModel.DataAnnotations;

namespace GerenciamentoServidores.Models
{
    public class Servidor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$",
            ErrorMessage = "Formato do telefone inválido. Use (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
        public string? Telefone { get; set; }  

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }  

        [Required(ErrorMessage = "O órgão é obrigatório.")]
        public int OrgaoId { get; set; }
        public Orgao Orgao { get; set; }

        [Required(ErrorMessage = "A lotação é obrigatória.")]
        public int LotacaoId { get; set; }
        public Lotacao Lotacao { get; set; }

        public string? Sala { get; set; }  

        [Required(ErrorMessage = "O status é obrigatório.")]
        public string Status { get; set; }
    }
}
