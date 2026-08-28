namespace CompanionStudio.Core.Logging;

public class CompanionLogEntry
{
    public string Level { get; }

    public string Message { get; }

    public DateTime CreatedAt { get; }


    public CompanionLogEntry(
        string level,
        string message)
    {
        Level = level;
        Message = message;
        CreatedAt = DateTime.UtcNow;
    }
}