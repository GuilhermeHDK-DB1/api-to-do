using System.ComponentModel.DataAnnotations;

namespace api_to_do.Dto.Request;

public class UpdateTarefaDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? State { get; set; }
}
