using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWorkExample.Data.Entities
{
    public class Pessoa
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        [ForeignKey("Evento")]
        public long EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
