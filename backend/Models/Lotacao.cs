
﻿namespace GerenciamentoServidores.Models
{
    public class Lotacao
    {
        public int Id { get; set; }  
        public string Nome { get; set; }  
        public int OrgaoId { get; set; }  
        public Orgao Orgao { get; set; }  
    }
}
