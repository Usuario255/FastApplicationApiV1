using System.ComponentModel.DataAnnotations.Schema;

namespace FastApplication.Domain.Entities
{
    [Table("Colaborador")]
    public class Colaborador
    {
        public Colaborador() { }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
