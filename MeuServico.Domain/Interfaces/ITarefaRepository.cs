using MeuServico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodosAsync();
        Task<Tarefa> ObterPorIdAsync(int id);
        Task AdicionarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task RemoverAsync(int id);
    }
}
