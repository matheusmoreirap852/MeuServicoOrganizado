using System;
using MeuServico.Domain.Entities;
using Xunit;

namespace MeuServicoOrganizado.Tests
{
    public class TarefaTests
    {
        [Fact]
        public void CriarTarefa_DeveSetarPropriedadesCorretamente()
        {
            // Arrange
            var titulo = "Nova Tarefa";
            var descricao = "Descrição da tarefa";
            var anotacoes = "Anotações importantes";
            var linhaTempo = "Hoje";

            // Act
            var tarefa = new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                Anotacoes = anotacoes,
                LinhaTempo = linhaTempo
            };

            // Assert
            Assert.Equal(titulo, tarefa.Titulo);
            Assert.Equal(descricao, tarefa.Descricao);
            Assert.Equal(anotacoes, tarefa.Anotacoes);
            Assert.Equal(linhaTempo, tarefa.LinhaTempo);
            Assert.NotNull(tarefa.DataCadastro);
            Assert.True(tarefa.DataCadastro.Value <= DateTime.Now);
        }
    }
}
