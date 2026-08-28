namespace CompanionStudio.Core.Events;

public class CompanionEventBus
{
    private readonly List<CompanionEvent> events;


    public CompanionEventBus()
    {
        events =
            new List<CompanionEvent>();
    }


    public void Publish(
        CompanionEvent companionEvent)
    {
        events.Add(companionEvent);
    }


    public IReadOnlyList<CompanionEvent> GetEvents()
    {
        return events;
    }


    public void Clear()
    {
        events.Clear();
    }
}