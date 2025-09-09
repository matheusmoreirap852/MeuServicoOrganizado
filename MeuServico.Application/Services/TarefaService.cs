using MeuServico.Application.DTOs;
using MeuServico.Application.Interfaces;
using MeuServico.Domain.Interfaces;
using MeuServico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuServico.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repo;

        public TarefaService(ITarefaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TarefaDTO>> ObterTodosAsync(string createdByUserId)
        {
            var tarefas = await _repo.ObterTodosAsync(createdByUserId);
            return tarefas.Select(t => MapToDto(t));
        }

        public async Task<TarefaDTO?> ObterPorIdAsync(int id, string createdByUserId)
        {
            var tarefa = await _repo.ObterPorIdAsync(id, createdByUserId);
            return tarefa is null ? null : MapToDto(tarefa);
        }

        public async Task<TarefaDTO> AdicionarAsync(CreateTarefaDTO dto, string createdByUserId)
        {
            var entity = new Tarefa
            {
                ClienteId       = dto.ClienteId,               // Guid
                Titulo          = dto.Titulo,
                Descricao       = dto.Descricao,
                Anotacoes       = dto.Anotacoes,
                LinhaTempo      = dto.LinhaTempo,
                DataCadastro    = DateTime.UtcNow,
                CreatedByUserId = createdByUserId
            };

            await _repo.AdicionarAsync(entity);
            return MapToDto(entity);
        }

        public async Task<TarefaDTO?> AtualizarAsync(int id, CreateTarefaDTO dto, string createdByUserId)
        {
            var existing = await _repo.ObterPorIdAsync(id, createdByUserId);
            if (existing is null) return null;

            existing.ClienteId  = dto.ClienteId;
            existing.Titulo     = dto.Titulo;
            existing.Descricao  = dto.Descricao;
            existing.Anotacoes  = dto.Anotacoes;
            existing.LinhaTempo = dto.LinhaTempo;

            await _repo.AtualizarAsync(existing);
            return MapToDto(existing);
        }

        public Task RemoverAsync(int id, string createdByUserId)
            => _repo.RemoverAsync(id, createdByUserId);

        private static TarefaDTO MapToDto(Tarefa t) => new TarefaDTO
        {
            Id           = t.Id,
            ClienteId    = t.ClienteId,
            ClienteNome  = t.Cliente?.Nome ?? string.Empty,
            Titulo       = t.Titulo,
            Descricao    = t.Descricao,
            Anotacoes    = t.Anotacoes,
            LinhaTempo   = t.LinhaTempo,
            DataCadastro = t.DataCadastro ?? DateTime.MinValue
        };
    }
}
