using FastApplication.Domain.Entities;
using FastApplication.Domain.Repositories;
using FastApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FastApplication.Infrastructure.Repositories
{
    public class WorkshopRepository : BaseRepository<Workshop, int>, IWorkshopRepository
    {
        public WorkshopRepository(DataDbContext context) : base(context)
        {
        }
    }
}
