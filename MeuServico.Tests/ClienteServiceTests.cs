using Xunit;
using MeuServicoOrganizado.Application.Services;
using MeuServicoOrganizado.Domain.Entities;

namespace MeuServicoOrganizado.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public void AdicionarCliente_DeveRetornarClienteCriado()
        {
            // Arrange
            var service = new ClienteService();
            var cliente = new Cliente("Matheus", "matheus@email.com");

            // Act
            var resultado = service.AdicionarCliente(cliente);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Matheus", resultado.Nome);
            Assert.Equal("matheus@email.com", resultado.Email);
        }
    }
}
