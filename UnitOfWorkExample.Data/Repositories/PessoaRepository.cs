using System.Threading.Tasks;
using UnitOfWorkExample.Data.Context;
using UnitOfWorkExample.Data.Entities;

namespace UnitOfWorkExample.Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly EventoContext _context;

        public PessoaRepository(EventoContext context)
        {
            _context = context;
        }

        public async Task AdicionarPessoa(Pessoa pessoa)
        {
            await _context.Pessoa.AddAsync(pessoa);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
