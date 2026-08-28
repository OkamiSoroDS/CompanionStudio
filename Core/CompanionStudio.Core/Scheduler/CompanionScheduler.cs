namespace CompanionStudio.Core.Scheduler;

public class CompanionScheduler
{
    private readonly List<CompanionTask> tasks;


    public CompanionScheduler()
    {
        tasks =
            new List<CompanionTask>();
    }


    public void Schedule(
        CompanionTask task)
    {
        tasks.Add(task);
    }


    public CompanionTask? Find(
        string id)
    {
        return tasks
            .FirstOrDefault(
                x => x.Id == id);
    }


    public void Run(
        string id)
    {
        var task =
            Find(id);


        if (task != null)
        {
            task.Complete();
        }
    }


    public IReadOnlyList<CompanionTask> GetAll()
    {
        return tasks;
    }
}