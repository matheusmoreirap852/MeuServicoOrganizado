// Project: MeuServico
using System;
using Microsoft.AspNetCore.Identity;

namespace MeuServico.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Você pode estender com novas propriedades, ex:
       
        public DateTime DataCadastro { get; set; }  
        public bool Ativo { get; set; }
    }
}
