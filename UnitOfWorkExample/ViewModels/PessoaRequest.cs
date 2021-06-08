using System;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWorkExample.ViewModels
{
    public class PessoaRequest
    {
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Range(1, long.MaxValue)]
        public long EventoId { get; set; } 
    }
}
