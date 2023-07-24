using api_to_do.Dto.Request;
using api_to_do.Dto.Response;
using api_to_do.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_to_do.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private static List<Tarefa> tarefas = new List<Tarefa>();
    private static int id = 0;
    private IMapper _mapper;

    public TarefaController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] CreateTarefaDto tarefaDto)
    {
        Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
        tarefa.Id = id++;
        tarefas.Add(tarefa);

        ReadTarefaDto tarefaResponse = _mapper.Map<ReadTarefaDto>(tarefa);
        return CreatedAtAction(nameof(GetTarefaById), 
            new { id = tarefaResponse.Id },
            tarefaResponse);
    }

    [HttpGet]
    public IEnumerable<ReadTarefaDto> GetTarefaPage([FromQuery] int skip=0, [FromQuery] int take=50)
    {
        List<ReadTarefaDto> tarefaResponse = _mapper.Map<List<ReadTarefaDto>>(tarefas);
        return tarefaResponse.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetTarefaById(int id) { 
        var tarefa = tarefas.FirstOrDefault(tarefa =>  tarefa.Id == id);
        if (tarefa == null) return NotFound();

        ReadTarefaDto tarefaResponse = _mapper.Map<ReadTarefaDto>(tarefa);
        return Ok(tarefaResponse);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTarefa(int id, [FromBody] UpdateTarefaDto tarefaDto)
    {
        int index = tarefas.IndexOf(tarefas.FirstOrDefault(tarefa => tarefa.Id == id));
        if (index == -1) return NotFound();
        var tarefaAtualizada = AtualizaTarefa(index, tarefaDto);

        ReadTarefaDto tarefaResponse = _mapper.Map<ReadTarefaDto>(tarefaAtualizada);
        return Ok(tarefaResponse);
    }

    private Tarefa AtualizaTarefa(int index, UpdateTarefaDto tarefaDto)
    {
        if(tarefaDto.Title != null) tarefas[index].Title = tarefaDto.Title;
        if (tarefaDto.Description != null) tarefas[index].Description = tarefaDto.Description;
        if (tarefaDto.State != null) tarefas[index].State = tarefaDto.State;
        return tarefas[index];
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTarefa(int id) {
        var tarefa = tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
        if (tarefa == null) return NotFound();
        tarefas.Remove(tarefa);
        return NoContent();
    }
}
