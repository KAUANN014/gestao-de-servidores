
﻿using System.ComponentModel.DataAnnotations;

namespace GerenciamentoServidores.DTOs
{
    public class ServidorCreateDto
    {

            [Required(ErrorMessage = "O nome é obrigatório.")]
            public string Nome { get; set; }

            [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Formato do telefone inválido. Use (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
            public string? Telefone { get; set; }

            [EmailAddress(ErrorMessage = "E-mail inválido.")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "O órgão é obrigatório.")]
            public int OrgaoId { get; set; }

            [Required(ErrorMessage = "A lotação é obrigatória.")]
            public int LotacaoId { get; set; }
            public string? Sala { get; set; }
            public string Status { get; set; }
        

    }
}
