using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;

namespace FastApplication.Application.Services
{
    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<Colaborador> CreateColaboradorAsync(Colaborador model)
        {
            return await _colaboradorRepository.InsertAsync(model); ;
        }

        public async Task<Colaborador> GetColaboradorAsync(int id)
        {
            return await _colaboradorRepository.GetByIdAsync(id);
        }

    }
}
