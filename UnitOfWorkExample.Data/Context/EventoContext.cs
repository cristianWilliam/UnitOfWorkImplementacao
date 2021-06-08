using Microsoft.EntityFrameworkCore;
using UnitOfWorkExample.Data.Entities;

namespace UnitOfWorkExample.Data.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Evento> Evento { get; set; }
    }
}
