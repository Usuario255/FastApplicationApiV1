using System.ComponentModel.DataAnnotations.Schema;

namespace FastApplication.Domain.Entities
{
    [Table("Workshop")]
    public class Workshop
    {
        public Workshop() {}

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRealizacao { get; set; }
        public string Descricao { get; set; }
    }
}
