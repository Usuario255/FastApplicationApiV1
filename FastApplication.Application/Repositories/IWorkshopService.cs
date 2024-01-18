using FastApplication.Domain.Entities;

namespace FastApplication.Application.Repositories
{
    public interface IWorkshopService
    {
        Task<Workshop> CadastrarWorkshop(Workshop workshopDto);
        Task<Workshop> GetWorkshopById(int id);
    }
}
