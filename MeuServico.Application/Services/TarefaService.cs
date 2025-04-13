using MeuServico.Application.DTOs;
using MeuServico.Application.Interfaces;
using MeuServico.Domain.Entities;
using MeuServico.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeuServico.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<IEnumerable<TarefaDTO>> ObterTodosAsync()
        {
            var tarefas = await _tarefaRepository.ObterTodosAsync();
            return tarefas.Select(t => new TarefaDTO
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                Anotacoes = t.Anotacoes,
                LinhaTempo = t.LinhaTempo,
                DataCadastro = t.DataCadastro
            });
        }

        public async Task<TarefaDTO> ObterPorIdAsync(int id)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(id);
            if (tarefa == null)
                return null;

            return new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Anotacoes = tarefa.Anotacoes,
                LinhaTempo = tarefa.LinhaTempo,
                DataCadastro = tarefa.DataCadastro
            };
        }

        public async Task AdicionarAsync(TarefaDTO tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Anotacoes = tarefaDto.Anotacoes,
                LinhaTempo = tarefaDto.LinhaTempo,
                DataCadastro = tarefaDto.DataCadastro
            };

            await _tarefaRepository.AdicionarAsync(tarefa);
        }

        public async Task AtualizarAsync(TarefaDTO tarefaDto)
        {
            var tarefa = new Tarefa
            {
                Id = tarefaDto.Id,
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Anotacoes = tarefaDto.Anotacoes,
                LinhaTempo = tarefaDto.LinhaTempo,
                DataCadastro = tarefaDto.DataCadastro
            };

            await _tarefaRepository.AtualizarAsync(tarefa);
        }

        public async Task RemoverAsync(int id)
        {
            await _tarefaRepository.RemoverAsync(id);
        }
    }
}
