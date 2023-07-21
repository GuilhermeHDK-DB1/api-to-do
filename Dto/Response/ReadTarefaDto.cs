using System.ComponentModel.DataAnnotations;

namespace api_to_do.Dto.Response;

public class ReadTarefaDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    //public string Description { get; set; }
    public string State { get; set; }
}
