using System.ComponentModel.DataAnnotations;

namespace Common.Models;
public class File
{
    public Guid Id { get; set; } 
    
    public string StorageKey { get; set; }
    
    public FileMetadata Metadata { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

