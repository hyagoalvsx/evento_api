using eventos_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace eventos_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Local> Locais { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Ingresso> Ingressos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento N:N entre Evento e Artista (Tabela: Evento_Artista)
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Artistas)
                .WithMany(a => a.Eventos)
                .UsingEntity<Dictionary<string, object>>(
                    "Evento_Artista",
                    j => j.HasOne<Artista>().WithMany().HasForeignKey("id_artista").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Evento>().WithMany().HasForeignKey("id_evento").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.ToTable("Evento_Artista");
                        j.HasKey("id_evento", "id_artista");
                    }
                );

            // Relacionamento N:N entre Evento e Cliente (Tabela: Participacao_Cliente_Evento)
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.ClientesParticipantes)
                .WithMany(c => c.EventosParticipantes)
                .UsingEntity<Dictionary<string, object>>(
                    "Participacao_Cliente_Evento",
                    j => j.HasOne<Cliente>().WithMany().HasForeignKey("id_cliente").OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne<Evento>().WithMany().HasForeignKey("id_evento").OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.ToTable("Participacao_Cliente_Evento");
                        j.HasKey("id_evento", "id_cliente");
                    }
                );
        }
    }
}