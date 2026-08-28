namespace CompanionStudio.Core.Backup;

public class CompanionBackupSystem
{
    private readonly List<CompanionBackup> backups;


    public CompanionBackupSystem()
    {
        backups =
            new List<CompanionBackup>();
    }


    public void Create(
        CompanionBackup backup)
    {
        backups.Add(
            backup);
    }


    public CompanionBackup? Find(
        string id)
    {
        return backups
            .FirstOrDefault(
                x => x.Id == id);
    }


    public void Restore(
        string id)
    {
        var backup =
            Find(id);


        if (backup != null)
        {
            backup.Restore();
        }
    }


    public IReadOnlyList<CompanionBackup> GetAll()
    {
        return backups;
    }
}