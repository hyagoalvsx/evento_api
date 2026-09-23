using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiGestaoProcessos.Entities
{

    [Table("clientes"), PrimaryKey(nameof(Id)), ]

    public class Clientes
    {
    [Column("id")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }

    }
}
