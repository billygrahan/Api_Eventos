using Microsoft.EntityFrameworkCore;
using Api_Eventos.Models;
using System.Text.Json;


namespace Api_Eventos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Evento>? Eventos { get; set; }
        public DbSet<Participante>? Participantes { get; set; }

        
    }
}
