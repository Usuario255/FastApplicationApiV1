using FastApplication.Domain.Entities;
using FastApplication.Infrastructure.Extensions;

namespace FastApplication.Application.Repositories
{
    public interface IAtaService
    {
        Task<Ata> CreateAtaAsync(Ata model);
        Task<Result<Ata>> AddColaboradorToAtaAsync(int ataId, int colaboradorId);
        Task<Result<Ata>> RemoveColaboradorFromAtaAsync(int ataId, int colaboradorId);
        Task<List<Ata>> GetAtasAsync(string workshopNome, DateTime? data);
    }
}
