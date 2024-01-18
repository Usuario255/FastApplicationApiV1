using FastApplication.Application.Repositories;
using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;
using FastApplication.Infrastructure.Extensions;

namespace FastApplication.Application.Services
{
    public class AtaService : IAtaService
    {
        private readonly IAtaRepository _ataRepository;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IColaboradorRepository _colaboradorRepository;

        public AtaService(IAtaRepository ataRepository, IWorkshopRepository workshopRepository, IColaboradorRepository colaboradorRepository)
        {
            _ataRepository = ataRepository;
            _workshopRepository = workshopRepository;
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<Ata> CreateAtaAsync(Ata model)
        {
            return await _ataRepository.InsertAsync(model); ;
        }

        public async Task<Result<Ata>> AddColaboradorToAtaAsync(int ataId, int colaboradorId)
        {
            var ata = await _ataRepository.GetByIdAsync(ataId);
            if (ata == null)
            {
                return Result<Ata>.Fail("Ata não encontrada.");
            }

            var colaborador = await _colaboradorRepository.GetByIdAsync(colaboradorId);
            if (colaborador == null)
            {
                return Result<Ata>.Fail("Colaborador não encontrado.");
            }
            
            if (!ata.Colaboradores.Any(c => c.Id == colaboradorId))
            {
                ata.Colaboradores.Add(colaborador);
                await _ataRepository.UpdateAsync(ata);
            }

            return Result<Ata>.Success(ata);
        }


        public async Task<Result<Ata>> RemoveColaboradorFromAtaAsync(int ataId, int colaboradorId)
        {
            var ata = await _ataRepository.GetByIdAsync(ataId);
            if (ata == null)
            {
                return Result<Ata>.Fail("Ata não encontrada.");
            }

            var colaborador = await _colaboradorRepository.GetByIdAsync(colaboradorId);
            if (colaborador == null)
            {
                return Result<Ata>.Fail("Colaborador não encontrado.");
            }
                       
            ata.Colaboradores.Remove(colaborador);

            await _ataRepository.UpdateAsync(ata);

            return Result<Ata>.Success(ata);
        }

        public async Task<List<Ata>> GetAtasAsync(string workshopNome, DateTime? data)
        {            
            var atas = await _ataRepository.GetAtasAsync(workshopNome, data);
            return atas;
        }
    }
}
