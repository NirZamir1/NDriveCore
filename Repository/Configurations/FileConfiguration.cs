using Common.Models.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Common.Models.File.File;

namespace Repository.Configurations;


public class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.ToTable("File");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.StorageKey)
            .IsRequired()
            .HasMaxLength(512);

        builder.HasIndex(f => f.StorageKey)
            .IsUnique();

        builder.HasOne(f => f.Metadata)
            .WithOne(m => m.File)
            .HasForeignKey<FileMetadata>(m => m.FileId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}