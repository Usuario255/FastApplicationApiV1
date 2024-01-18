using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;
using FastApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastApplication.Infrastructure.Repositories
{
    public class AtaRepository : BaseRepository<Ata, int>, IAtaRepository
    {
        public AtaRepository(DataDbContext context) : base(context)
        {

        }

        public async Task<List<Ata>> GetAtasAsync(string workshopNome, DateTime? data)
        {
            IQueryable<Ata> query = _context.Atas;

            if (!string.IsNullOrEmpty(workshopNome))
            {
                query = query.Where(ata => ata.Workshop.Nome == workshopNome);
            }

            if (data.HasValue)
            {
                query = query.Where(ata => ata.Workshop.DataRealizacao.Date == data.Value.Date);
            }

            return await query.ToListAsync();
        }
        
    }
}
