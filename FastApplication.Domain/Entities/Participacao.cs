namespace FastApplication.Domain.Entities
{
    public class Participacao
    {
        public Participacao(){}
      
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

        public int ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }

        public int AtaId { get; set; }
        public Ata Ata { get; set; }
    }
}
