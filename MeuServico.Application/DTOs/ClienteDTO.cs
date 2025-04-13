using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuServico.Domain.Entities;

namespace MeuServico.Application.DTOs
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}