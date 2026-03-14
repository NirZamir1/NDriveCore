using Microsoft.EntityFrameworkCore;
using Common.Models;
using File = Common.Models.File;

namespace Repository;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    
    public DbSet<File> Files { get; set; }
    public DbSet<FileMetadata> FilesMetadata { get; set; }
}