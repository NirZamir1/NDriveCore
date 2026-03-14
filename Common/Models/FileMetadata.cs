namespace Common.Models;

public class FileMetadata
{
    public Guid FileId { get; set; }
    public File File { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public long Size { get; set; }

    public string MimeType { get; set; } = null!;
}