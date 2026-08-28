namespace CompanionStudio.Core.Events;

public class CompanionEventSystem
{
    private readonly List<CompanionEvent> events;


    public CompanionEventSystem()
    {
        events = new List<CompanionEvent>();
    }


    public void Publish(
        CompanionEvent companionEvent)
    {
        events.Add(companionEvent);
    }


    public IReadOnlyList<CompanionEvent> GetAll()
    {
        return events;
    }
}