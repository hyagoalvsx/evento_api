using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace eventos_api.Entities
{
    [Table("Clientes"), PrimaryKey(nameof(IdCliente))]
    public class Cliente
    {
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("telefone")]
        public string? Telefone { get; set; }

        public ICollection<Ingresso>? Ingressos { get; set; }
        public ICollection<Evento>? EventosParticipantes { get; set; }
    }
}