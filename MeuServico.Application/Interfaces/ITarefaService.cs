using MeuServico.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> ObterTodosAsync();
        Task<TarefaDTO> ObterPorIdAsync(int id);
        Task AdicionarAsync(TarefaDTO tarefa, string createdByUserId);
        Task AtualizarAsync(TarefaDTO tarefa, string createdByUserId);
        Task RemoverAsync(int id);
    }
}
