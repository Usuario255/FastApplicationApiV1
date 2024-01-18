using FastApplication.Domain.Entities;

namespace FastApplication.Application.Repositories
{
    public interface IColaboradorService
    {
        Task<Colaborador> CreateColaboradorAsync(Colaborador model);
        Task<Colaborador> GetColaboradorAsync(int id);
    }
}
