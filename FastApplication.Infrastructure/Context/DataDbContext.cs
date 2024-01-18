using FastApplication.Domain.Entities;
using FastApplication.Infrastructure.EntityMappings;
using Microsoft.EntityFrameworkCore;

namespace FastApplication.Infrastructure.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

        }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Workshop> Workshop { get; set; }
        public DbSet<Ata> Atas{ get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorConfiguration());
            modelBuilder.ApplyConfiguration(new WorkshopConfiguration());
            modelBuilder.ApplyConfiguration(new AtaConfiguration());
        }      
    }
}
