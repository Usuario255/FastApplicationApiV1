using FastApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastApplication.Infrastructure.EntityMappings
{
    public class WorkshopConfiguration : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Nome).IsRequired().HasMaxLength(255);
            builder.Property(w => w.DataRealizacao).IsRequired();
            builder.Property(w => w.Descricao).IsRequired();
        }
    }
}
