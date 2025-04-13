using System;
using System.ComponentModel.DataAnnotations;

namespace MeuServico.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public string Descricao { get; set; }
        
        public string Anotacoes { get; set; }
        
        public string? LinhaTempo { get; set; }
        
        public DateTime? DataCadastro { get; set; } = DateTime.Now;
    }
}
