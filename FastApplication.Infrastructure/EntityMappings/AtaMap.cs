using FastApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastApplication.Infrastructure.EntityMappings
{
    public class AtaConfiguration : IEntityTypeConfiguration<Ata>
    {
        public void Configure(EntityTypeBuilder<Ata> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Workshop)
                .WithMany()
                .HasForeignKey(a => a.WorkshopId)
                .IsRequired();
        }
    }
}
