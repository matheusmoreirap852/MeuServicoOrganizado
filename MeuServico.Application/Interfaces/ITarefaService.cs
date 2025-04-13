using MeuServico.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> ObterTodosAsync();
        Task<TarefaDTO> ObterPorIdAsync(int id);
        Task AdicionarAsync(TarefaDTO tarefa);
        Task AtualizarAsync(TarefaDTO tarefa);
        Task RemoverAsync(int id);
    }
}
