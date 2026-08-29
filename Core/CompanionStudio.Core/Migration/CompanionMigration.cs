namespace CompanionStudio.Core.Migration;

public class CompanionMigration
{
    public string FromVersion { get; }

    public string ToVersion { get; }

    public bool Completed { get; private set; }

    public DateTime? CompletedAt { get; private set; }


    public CompanionMigration(
        string fromVersion,
        string toVersion)
    {
        FromVersion = fromVersion;

        ToVersion = toVersion;

        Completed = false;
    }


    public void Complete()
    {
        Completed = true;

        CompletedAt = DateTime.UtcNow;
    }
}