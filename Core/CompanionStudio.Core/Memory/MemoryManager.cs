namespace CompanionStudio.Core.Memory;

public class MemoryManager
{
    private int counter = 0;

    public MemoryModel CreateMemory(
        string type,
        string content,
        int importance)
    {
        counter++;

        return new MemoryModel
        {
            Id = $"MEM-{counter:D6}",
            Type = type,
            Content = content,
            Importance = importance,
            CreatedAt = DateTime.Now
        };
    }
}