using MeuServico.Domain.Entities;
using MeuServico.Domain.Interfaces;
using MeuServico.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeuServico.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterTodosAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task AdicionarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var tarefa = await ObterPorIdAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
