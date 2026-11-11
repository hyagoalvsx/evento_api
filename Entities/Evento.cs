using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventos_api.Entities
{
    [Table("Eventos"), PrimaryKey(nameof(IdEvento))]
    public class Evento
    {
        [Column("id_evento")]
        public int IdEvento { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("descricao", TypeName = "text")]
        public string? Descricao { get; set; }

        [Column("data")]
        public DateOnly Data { get; set; }

        [Column("horario")]
        public TimeOnly Horario { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [Column("id_local")]
        public int? IdLocal { get; set; }

        [ForeignKey("IdLocal")]
        public Local? Local { get; set; }

        public ICollection<Artista>? Artistas { get; set; }
        public ICollection<Cliente>? ClientesParticipantes { get; set; }
        public ICollection<Ingresso>? Ingressos { get; set; }
    }
}