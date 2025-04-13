using MeuServico.Application.DTOs;
using MeuServico.Application.Interfaces;
using MeuServico.Domain.Entities;
using MeuServico.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq; // Adicione esta linha
using System.Threading.Tasks;

namespace MeuServico.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;

        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClienteDTO>> ObterTodosAsync()
        {
            var clientes = await _repo.ObterTodosAsync();
            return clientes.Select(c => new ClienteDTO { Id = c.Id, Nome = c.Nome, Email = c.Email });
        }

        public async Task<ClienteDTO?> ObterPorIdAsync(Guid id)
        {
            var c = await _repo.ObterPorIdAsync(id);
            return c == null ? null : new ClienteDTO { Id = c.Id, Nome = c.Nome, Email = c.Email };
        }

        public async Task AdicionarAsync(ClienteDTO dto)
        {
            var c = new Cliente { Id = Guid.NewGuid(), Nome = dto.Nome, Email = dto.Email };
            await _repo.AdicionarAsync(c);
        }

        public async Task AtualizarAsync(ClienteDTO dto)
        {
            var c = new Cliente { Id = dto.Id, Nome = dto.Nome, Email = dto.Email };
            await _repo.AtualizarAsync(c);
        }

        public async Task RemoverAsync(Guid id) => await _repo.RemoverAsync(id);
    }
}
