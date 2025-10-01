using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;
using Microsoft.EntityFrameworkCore;
using movies_api.controllers;

namespace movies_api.data
{
    public class MoviesContext : DbContext
    {
        public DbSet<Assento> Assentos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>()
            .HasMany(s => s.Assentos)
            .WithOne(a => a.Sessao)
            .HasForeignKey(a => a.SessaoId);

            modelBuilder.Entity<Usuario>()
            .HasMany(u => u.AssentosReservados)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.UsuarioId);
        }
    }
}