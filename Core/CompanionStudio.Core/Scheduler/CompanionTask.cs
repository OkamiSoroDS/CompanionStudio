namespace CompanionStudio.Core.Scheduler;

public class CompanionTask
{
    public string Id { get; }

    public string Name { get; }

    public bool Completed { get; private set; }


    public CompanionTask(
        string id,
        string name)
    {
        Id = id;
        Name = name;
        Completed = false;
    }


    public void Complete()
    {
        Completed = true;
    }
}