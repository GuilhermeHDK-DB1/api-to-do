using System.ComponentModel.DataAnnotations;

namespace api_to_do.Dto.Request;

public class UpdateTarefaDto
{
    [Required(ErrorMessage = "O campo title é obrigatório")]
    public string Title { get; set; }
    [Required(ErrorMessage = "O campo description é obrigatório")]
    public string Description { get; set; }
    [Required(ErrorMessage = "O campo state é obrigatório")]
    public string State { get; set; }
}
