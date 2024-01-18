using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;
using FastApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastApplication.Infrastructure.Repositories
{
    public class ColaboradorRepository : BaseRepository<Colaborador, int>, IColaboradorRepository
    {
        public ColaboradorRepository(DataDbContext context) : base(context)
        {
        }
    }
}
