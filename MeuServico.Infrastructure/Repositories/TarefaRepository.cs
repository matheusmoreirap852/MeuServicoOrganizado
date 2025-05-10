using MeuServico.Domain.Entities;
using MeuServico.Domain.Interfaces;
using MeuServico.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Tarefa>> ObterTodosAsync(string createdByUserId)
        {
            return await _context.Tarefas
                .Include(t => t.Cliente)
                .Where(t => t.CreatedByUserId == createdByUserId)
                .ToListAsync();
        }

        public async Task<Tarefa?> ObterPorIdAsync(int id, string createdByUserId)
        {
            return await _context.Tarefas
                .Include(t => t.Cliente)
                .FirstOrDefaultAsync(t => t.Id == id && t.CreatedByUserId == createdByUserId);
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

        public async Task RemoverAsync(int id, string createdByUserId)
        {
            var tarefa = await ObterPorIdAsync(id, createdByUserId);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
