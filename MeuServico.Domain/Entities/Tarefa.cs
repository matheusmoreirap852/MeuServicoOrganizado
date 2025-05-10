using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MeuServico.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        // FK para cliente
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public string Descricao { get; set; } = string.Empty;
        public string Anotacoes { get; set; } = string.Empty;
        public string? LinhaTempo { get; set; }
        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        // FK para usuário criador
        public string CreatedByUserId { get; set; } = string.Empty;
    }
}
