using System.ComponentModel.DataAnnotations.Schema;

namespace FastApplication.Domain.Entities
{
    [Table("Ata")]
    public class Ata 
    {
        public Ata()
        {
            Colaboradores = new List<Colaborador>();
        }

        public int Id { get; set; }
        public int WorkshopId{ get; set; }
        public Workshop Workshop { get; set; }
        public List<Colaborador> Colaboradores { get; set; }
    }
}
