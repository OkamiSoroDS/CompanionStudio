namespace CompanionStudio.Core.Backup;

public class CompanionBackup
{
    public string Id { get; }

    public DateTime CreatedAt { get; }

    public bool Restored { get; private set; }


    public CompanionBackup(
        string id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        Restored = false;
    }


    public void Restore()
    {
        Restored = true;
    }
}