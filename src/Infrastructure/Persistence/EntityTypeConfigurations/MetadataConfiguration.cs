using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpStorage.Domain;

namespace SimpStorage.Infrastructure.Persistence.EntityTypeConfigurations
{
    internal class MetadataConfiguration : IEntityTypeConfiguration<Metadata>
    {
        public void Configure(EntityTypeBuilder<Metadata> builder)
        {
            // base properties
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired();

            // Entity properties
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.Filename).IsRequired();
            builder.Property(x => x.Extension).IsRequired();
        }
    }
}
