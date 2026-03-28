using System.ComponentModel.DataAnnotations;

namespace Common.Models.File;
public class File
{
    public Guid Id { get; set; } 
    
    public string StorageKey { get; set; }
    
    public FileMetadata Metadata { get; set; }
}

