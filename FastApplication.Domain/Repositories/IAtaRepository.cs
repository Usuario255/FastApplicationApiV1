using FastApplication.Domain.Entities;

namespace FastApplication.Domain.Repositories
{
    public interface IAtaRepository : IBaseRepository<Ata, int>
    {       
        Task<List<Ata>> GetAtasAsync(string workshopNome, DateTime? data);
    }
}
