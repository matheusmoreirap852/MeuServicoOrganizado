using MeuServico.Application.DTOs;    // for CreateTarefaDTO, TarefaDTO
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> ObterTodosAsync(string createdByUserId);
        Task<TarefaDTO?> ObterPorIdAsync(int id, string createdByUserId);
        Task<TarefaDTO> AdicionarAsync(CreateTarefaDTO dto, string createdByUserId);
        Task<TarefaDTO?> AtualizarAsync(int id, CreateTarefaDTO dto, string createdByUserId);
        Task RemoverAsync(int id, string createdByUserId);
    }
}
