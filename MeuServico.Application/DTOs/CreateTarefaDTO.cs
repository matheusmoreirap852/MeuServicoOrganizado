using System;
using System.ComponentModel.DataAnnotations;

namespace MeuServico.Application.DTOs
{
    public class CreateTarefaDTO
{
    [Required]
    public Guid ClienteId   { get; set; } // ✅ corrigido
    public string Titulo    { get; set; } = "";
    public string Descricao { get; set; } = "";
    public string Anotacoes { get; set; } = "";
    public string LinhaTempo { get; set; } = "";
}

}
