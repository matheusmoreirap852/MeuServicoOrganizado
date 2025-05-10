public class Tarefa
{
    [Key] public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public Guid ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public string Anotacoes { get; set; } = string.Empty;
    public string? LinhaTempo { get; set; }
    public DateTime? DataCadastro { get; set; } = DateTime.Now;

    // **Importante**: campo para o usuário que criou a tarefa
    public string CreatedByUserId { get; set; } = string.Empty;
}
