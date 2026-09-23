using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ClientesDto
    {
    [Required(ErrorMessage ="o campo 'nome' é obrigatorio fih")]
    public required string Nome { get; set; }
    }
}
