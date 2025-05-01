using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RamosJ_LigaPro.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<RamosJ_LigaPro.Models.Equipo> Equipo { get; set; } = default!;
        public DbSet<RamosJ_LigaPro.Models.Jugador> Jugador { get; set; } = default!;
        public DbSet<RamosJ_LigaPro.Models.Plantilla> Plantilla { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plantilla>()
            .HasKey(p => new { p.EquipoId, p.JugadorId });
        modelBuilder.Entity<Plantilla>()
            .HasOne(p => p.Equipo)
            .WithMany(e => e.Plantillas)
            .HasForeignKey(p => p.EquipoId);
        modelBuilder.Entity<Plantilla>()
            .HasOne(p => p.Jugador)
            .WithMany(j => j.Plantillas)
            .HasForeignKey(p => p.JugadorId);
    }
}
