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
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sala> Salas { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assento>()
                .HasMany(a => a.Reservas)
                .WithMany(r => r.Assentos);
        }
    }
}