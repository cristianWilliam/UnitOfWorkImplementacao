using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UnitOfWorkExample.Data.Entities;
using UnitOfWorkExample.Data.Repositories;
using UnitOfWorkExample.ViewModels;

namespace UnitOfWorkExample.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaRepository _pessoaRepo;
        private readonly IEventoRepository _eventoRepo;

        public PessoaController(IPessoaRepository pessoaRepo, IEventoRepository eventoRepo)
        {
            _pessoaRepo = pessoaRepo;
            _eventoRepo = eventoRepo;
        }

        [HttpPost]
        public async Task<PessoaViewModel>AdicionarPessoa([FromBody] PessoaRequest pessoa)
        {
            var pessoaModel = new Pessoa
            {
                EventoId = pessoa.EventoId,
                Nome = pessoa.Nome
            };

            await _pessoaRepo.AdicionarPessoa(pessoaModel);

            await _eventoRepo.IncrementarPessoa(pessoa.EventoId);

            await _pessoaRepo.Commit();

            return new PessoaViewModel
            {
                EventoId = pessoaModel.EventoId,
                Nome = pessoaModel.Nome,
                Id = pessoaModel.Id
            };

        }
    }
}
