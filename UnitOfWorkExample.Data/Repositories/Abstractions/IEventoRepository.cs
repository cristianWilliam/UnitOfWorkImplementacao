using System.Threading.Tasks;
using UnitOfWorkExample.Data.Repositories.Abstractions;

namespace UnitOfWorkExample.Data.Repositories
{
    public interface IEventoRepository : IUnitOfWork
    {
        Task IncrementarPessoa(long eventoId);
    }
}
