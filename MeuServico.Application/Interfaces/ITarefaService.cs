using MeuServico.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> ObterTodosAsync();
        Task<TarefaDTO?>              ObterPorIdAsync(int id);
        // Recebe também o UserId de quem criou a tarefa
        Task AdicionarAsync(TarefaDTO tarefaDto, string createdByUserId);
        Task AtualizarAsync(TarefaDTO tarefaDto);
        Task RemoverAsync(int id);
    }
}
