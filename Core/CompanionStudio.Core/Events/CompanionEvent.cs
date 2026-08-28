namespace CompanionStudio.Core.Events;

public class CompanionEvent
{
    public string Name { get; }

    public DateTime CreatedAt { get; }


    public CompanionEvent(
        string name)
    {
        Name = name;

        CreatedAt = DateTime.UtcNow;
    }
}