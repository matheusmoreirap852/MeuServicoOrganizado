using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuServico.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // *** Adicione esta propriedade ***
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}