using Microsoft.AspNetCore.Mvc;
using MeuServico.Application.DTOs;
using MeuServico.Application.Interfaces;
using System.Threading.Tasks;

namespace MeuServico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: api/Tarefa
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = await _tarefaService.ObterTodosAsync();
            return Ok(tarefas);
        }

        // GET: api/Tarefa/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tarefa = await _tarefaService.ObterPorIdAsync(id);
            if (tarefa == null)
                return NotFound();
            return Ok(tarefa);
        }

        // POST: api/Tarefa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarefaDTO tarefaDto)
        {
            await _tarefaService.AdicionarAsync(tarefaDto);
            // Opcional: retornar o recurso criado com CreatedAtAction
            return CreatedAtAction(nameof(GetById), new { id = tarefaDto.Id }, tarefaDto);
        }

        // PUT: api/Tarefa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TarefaDTO tarefaDto)
        {
            if (id != tarefaDto.Id)
                return BadRequest("O ID da rota não coincide com o ID do objeto.");

            await _tarefaService.AtualizarAsync(tarefaDto);
            return NoContent();
        }

        // DELETE: api/Tarefa/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tarefaService.RemoverAsync(id);
            return NoContent();
        }
    }
}
