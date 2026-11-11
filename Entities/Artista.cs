using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace eventos_api.Entities
{
    [Table("Artistas"), PrimaryKey(nameof(IdArtista))]
    public class Artista
    {
        [Column("id_artista")]
        public int IdArtista { get; set; }

        [Column("nome_artistico")]
        public string NomeArtistico { get; set; } = string.Empty;

        [Column("nome_completo")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Column("genero_musical")]
        public string? GeneroMusical { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}