using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace eventos_api.Entities
{
    [Table("Locais"), PrimaryKey(nameof(IdLocal))]
    public class Local
    {
        [Column("id_local")]
        public int IdLocal { get; set; }

        [Column("nome")]
        public string Nome { get; set; } = string.Empty;

        [Column("endereco")]
        public string Endereco { get; set; } = string.Empty;

        [Column("capacidade")]
        public int Capacidade { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}