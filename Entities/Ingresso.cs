using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventos_api.Entities
{
    [Table("Ingressos"), PrimaryKey(nameof(IdIngresso))]
    public class Ingresso
    {
        [Column("id_ingresso")]
        public int IdIngresso { get; set; }

        [Column("tipo")]
        public string Tipo { get; set; } = string.Empty;

        [Column("preco", TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [Column("id_evento")]
        public int IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }

        [Column("id_cliente")]
        public int? IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
    }
}