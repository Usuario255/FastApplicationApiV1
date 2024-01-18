using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;

namespace FastApplication.Application.Services
{
    public class WorkshopService : IWorkshopService
    {
        private readonly IWorkshopRepository _workshopRepository;

        public WorkshopService(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        public async Task<Workshop> CadastrarWorkshop(Workshop workshopDto)
        {
            return await _workshopRepository.InsertAsync(workshopDto);
        }

        public async Task<Workshop> GetWorkshopById(int id)
        {
            return await _workshopRepository.GetByIdAsync(id);
        }
    }

}
