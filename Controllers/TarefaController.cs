using api_to_do.Models;
using Microsoft.AspNetCore.Mvc;


namespace api_to_do.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private static List<Tarefa> tarefas = new List<Tarefa>();
    private static int id = 0;

    [HttpPost]
    public IActionResult CreateTask([FromBody] Tarefa tarefa)
    {
        tarefa.Id = id++;
        tarefas.Add(tarefa);
        return CreatedAtAction(nameof(GetTarefaById), 
            new { id = tarefa.Id }, 
            tarefa);
    }

    [HttpGet]
    public IEnumerable<Tarefa> GetTarefaPage([FromQuery] int skip=0, [FromQuery] int take=50)
    {
        return tarefas.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetTarefaById(int id) { 
        var tarefa = tarefas.FirstOrDefault(tarefa =>  tarefa.Id == id);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTarefa(int id) {
        var tarefa = tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
        if (tarefa == null) return NotFound();
        tarefas.Remove(tarefa);
        return NoContent();

    }
}
