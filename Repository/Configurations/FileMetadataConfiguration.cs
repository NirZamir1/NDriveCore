using Common.Models;
using Common.Models.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations;

public class FileMetadataConfiguration : IEntityTypeConfiguration<FileMetadata>
{
    public void Configure(EntityTypeBuilder<FileMetadata> builder)
    {
        builder.UseTptMappingStrategy();
        
        builder.ToTable("FileMetadata");

        builder.HasKey(m => m.FileId);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(f => f.CreatedAt)
            .IsRequired();

        builder.Property(f => f.UpdatedAt);

        builder.Property(m => m.Size).IsRequired();
        
        builder.Property(m => m.MimeType)
            .IsRequired()
            .HasMaxLength(128);
    }
}