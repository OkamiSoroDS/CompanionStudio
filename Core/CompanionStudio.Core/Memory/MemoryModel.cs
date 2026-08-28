namespace CompanionStudio.Core.Memory;

public class MemoryModel
{
    public string Id { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int Importance { get; set; }

    public DateTime CreatedAt { get; set; }
}