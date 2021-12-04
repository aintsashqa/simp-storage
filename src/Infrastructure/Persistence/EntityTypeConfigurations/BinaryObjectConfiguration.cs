using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpStorage.Domain;

namespace SimpStorage.Infrastructure.Persistence.EntityTypeConfigurations
{
    internal class BinaryObjectConfiguration : IEntityTypeConfiguration<BinaryObject>
    {
        public void Configure(EntityTypeBuilder<BinaryObject> builder)
        {
            // base properties
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired();

            // Entity properties
            builder.Property(x => x.Data).IsRequired();
            builder.Property<Guid>("MetadataForeignKey");
            builder.HasOne(x => x.Metadata).WithOne(x => x.BinaryObject)
                .HasForeignKey<BinaryObject>("MetadataForeignKey").IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
