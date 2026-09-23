using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiGestaoProcessos.Dtos
{
    public class ProcessoDto
    {
        [Required(ErrorMessage ="o campo 'numero' é obrigatorio vey'")]
        public required string Numero { get; set; } = string.Empty;

        [Required]
        public DateOnly Data { get; set; }

        [Required(ErrorMessage = "o campo 'interessado' é obrigatorio vey'")]
        [MinLength(5, ErrorMessage ="Obrigatorio minimo de 5 caracteres")]
        public required string Interessado { get; set; }

        [Required]
        [MinLength(5)]
        public required string Assunto { get; set; }
        public string? Descricao { get; set; }
    }

    public class ProcessoUpdateDto : ProcessoDto
    {
        public string? Situacao { get; set; }
    }
}
