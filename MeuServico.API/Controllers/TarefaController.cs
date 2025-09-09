using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using MeuServico.Application.DTOs;
using MeuServico.Application.Interfaces;

namespace MeuServico.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) 
                return Unauthorized();

            var tarefas = await _tarefaService.ObterTodosAsync(userId);
            return Ok(tarefas);
        }

        // GET: api/Tarefa/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) 
                return Unauthorized();

            var tarefa = await _tarefaService.ObterPorIdAsync(id, userId);
            if (tarefa == null) 
                return NotFound();
            return Ok(tarefa);
        }

        // POST: api/Tarefa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTarefaDTO dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) 
                return Unauthorized();

            var created = await _tarefaService.AdicionarAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/Tarefa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateTarefaDTO dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) 
                return Unauthorized();

            var updated = await _tarefaService.AtualizarAsync(id, dto, userId);
            if (updated == null) 
                return NotFound();
            return Ok(updated);
        }

        // DELETE: api/Tarefa/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) 
                return Unauthorized();

            await _tarefaService.RemoverAsync(id, userId);
            return NoContent();
        }
    }
}
