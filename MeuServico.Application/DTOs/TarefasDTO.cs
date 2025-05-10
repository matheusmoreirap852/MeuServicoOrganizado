using System;

namespace MeuServico.Application.DTOs
{
    public class TarefaDTO
    {
        public int    Id               { get; set; }
        public string Titulo           { get; set; } = string.Empty;
        public string Descricao        { get; set; } = string.Empty;
        public string Anotacoes        { get; set; } = string.Empty;
        public string? LinhaTempo      { get; set; }
        public DateTime? DataCadastro  { get; set; }
        public string CreatedByUserId  { get; set; } = string.Empty;
    }
}
