# Meu Serviço Organizado — API de tarefas

API REST em C# e ASP.NET Core para organizar tarefas e clientes. Aplicativo complementar: [MyTarefaApp](https://github.com/matheusmoreirap852/MyTarefaApp).

## Tecnologias

.NET 8, ASP.NET Core Web API, Entity Framework Core, SQLite e Swagger.

## Arquitetura

| Camada | Responsabilidade |
| --- | --- |
| MeuServico.API | Controllers e configuração HTTP |
| MeuServico.Application | DTOs, interfaces e serviços de aplicação |
| MeuServico.Domain | Entidades e contratos de repositórios |
| MeuServico.Infrastructure | DbContext, migrations e persistência |
| MeuServico.Tests | Estrutura inicial de testes |

Os serviços e repositórios são registrados por injeção de dependências.

## Executar localmente

Requer SDK .NET 8 e ferramenta dotnet-ef compatível com o EF Core do projeto. Clone o repositório, entre na pasta e configure ConnectionStrings:DefaultConnection para um banco SQLite local. Exemplo em macOS/Linux:

```bash
export ConnectionStrings__DefaultConnection="Data Source=tarefas.db"
dotnet restore MeuServico.API/MeuServico.API.csproj
dotnet ef database update --project MeuServico.Infrastructure --startup-project MeuServico.API
dotnet run --project MeuServico.API --launch-profile MeuServico.API
```

O perfil define HTTP em http://localhost:5000 e HTTPS em https://localhost:5001. O Swagger fica em /swagger no ambiente Development. A aplicação usa redirecionamento para HTTPS. Estes comandos descrevem o código; a execução não foi validada nesta revisão de documentação.

## Endpoints de tarefas

| Método | Rota | Ação |
| --- | --- | --- |
| GET | /api/Tarefa | Listar |
| GET | /api/Tarefa/{id} | Consultar |
| POST | /api/Tarefa | Criar |
| PUT | /api/Tarefa/{id} | Atualizar |
| DELETE | /api/Tarefa/{id} | Remover |

O projeto também contém ClienteController. Consulte os DTOs e o Swagger para os contratos completos.

## Integração mobile

A baseURL em src/Services/api.js do MyTarefaApp precisa apontar para a API, incluindo /api. No celular físico, localhost é o próprio celular; use um endereço de desenvolvimento acessível pelo dispositivo.

## Estado do projeto

Projeto pessoal em evolução. O teste inicial em MeuServico.Tests ainda não possui asserções e não representa cobertura das regras de negócio. Próximas melhorias: testes efetivos, validações, autenticação e padronização de erros. O CORS atual é amplo para desenvolvimento e precisa ser ajustado antes de produção.
