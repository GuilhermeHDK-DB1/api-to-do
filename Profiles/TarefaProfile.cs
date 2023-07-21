using api_to_do.Dto.Request;
using api_to_do.Dto.Response;
using api_to_do.Models;
using AutoMapper;

namespace api_to_do.Profiles;

public class TarefaProfile : Profile
{
    public TarefaProfile() {
        CreateMap<CreateTarefaDto, Tarefa>();
        CreateMap<UpdateTarefaDto, Tarefa>();
        CreateMap<Tarefa, ReadTarefaDto>();
    }
}
