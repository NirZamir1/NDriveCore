namespace Common.Models.File;

public class FileMetadata
{
    public Guid FileId { get; set; }
    public File File { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public long Size { get; set; }

    public string MimeType { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}