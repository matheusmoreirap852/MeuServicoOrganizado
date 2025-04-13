using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuServico.Application.DTOs;

namespace MeuServico.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObterTodosAsync();
        Task<ClienteDTO?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(ClienteDTO cliente);
        Task AtualizarAsync(ClienteDTO cliente);
        Task RemoverAsync(Guid id);
    }
}