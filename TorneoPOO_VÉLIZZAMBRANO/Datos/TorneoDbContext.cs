using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoPOO_VÉLIZZAMBRANO.Datos
{
    public class TorneoDbContext: DbContext
    {
        //1 . Dbst para cada clase que se quiera mapear a la base de datos
        public DbSet<Moddel.Equipo> Equipos { get; set; }
        public DbSet<Moddel.Jugador> Jugadores { get; set; }
        public DbSet<Moddel.Partido> Partidos { get; set; }

        //2. Configurar la cadena de conexión a la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //cadena conexion Usuario SQL Server
            optionsBuilder.UseSqlServer("Server=Sebastian;Database=TORNEO_AZAMBRANO;User Id=sa;Password=123456;TrustServerCertificate=True;");
            
            // Cadena conexion Usuario Windows
            //optionsBuilder.UseSqlServer("Server=Sebastian;Database=TORNEO_AZAMBRANO;Trusted_Connection=True;");
        }

        //3. configurar las relaciones entre las tablas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion 1 a muchos entre Equipo y Jugador
            modelBuilder.Entity<Moddel.Equipo>()
                .HasMany(e => e.Jugadores)
                .WithOne(j => j.EquipoActual)
                .HasForeignKey(j => j.EquipoId)
                .OnDelete(DeleteBehavior.Cascade);

            //Relacion 1 a muchos entre Partido y Equipo (local y visitante)
            modelBuilder.Entity<Moddel.Partido>()
                .HasOne(p => p.Local)
                .WithMany()
                .HasForeignKey(p => p.LocalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Moddel.Partido>()
                .HasOne(p => p.Visitante)
                .WithMany()
                .HasForeignKey(p => p.VisitanteId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
