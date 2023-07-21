using System.ComponentModel.DataAnnotations;

namespace api_to_do.Models;

public class Tarefa
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo title é obrigatório")]
    public string Title { get ; set; }
    [Required(ErrorMessage = "O campo description é obrigatório")]
    public string Description { get; set; }
    [Required(ErrorMessage = "O campo state é obrigatório")]
    public string State { get; set; }

}
