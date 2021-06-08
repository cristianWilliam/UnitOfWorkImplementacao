using System;
using System.Threading.Tasks;
using UnitOfWorkExample.Data.Context;

namespace UnitOfWorkExample.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventoContext _context;

        public EventoRepository(EventoContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task IncrementarPessoa(long eventoId)
        {
            var evento = await _context.Evento.FindAsync(eventoId);

            if (evento == null)
                throw new Exception("Evento nao encontrado");

            if (evento.QtdAtual == evento.QtdMax)
                throw new Exception("Evento não há vagas disponiveis");

            evento.QtdAtual += 1;

            _context.Evento.Update(evento);
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
