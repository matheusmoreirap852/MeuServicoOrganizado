using MeuServico.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterTodosAsync(string createdByUserId);
        Task<Tarefa?> ObterPorIdAsync(int id, string createdByUserId);
        Task AdicionarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task RemoverAsync(int id, string createdByUserId);
    }
}
