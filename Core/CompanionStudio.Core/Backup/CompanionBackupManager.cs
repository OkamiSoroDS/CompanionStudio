using CompanionStudio.Core.Package;
using CompanionStudio.Core.Storage;

namespace CompanionStudio.Core.Backup;

public class CompanionBackupManager
{
    private readonly CompanionStorageManager storage;


    public CompanionBackupManager()
    {
        storage =
            new CompanionStorageManager();
    }


    public void CreateBackup(
        CompanionPackage package,
        string backupPath)
    {
        storage.Save(
            package,
            backupPath);
    }


    public CompanionPackage? RestoreBackup(
        string backupPath)
    {
        return storage.Load(
            backupPath);
    }


    public bool Exists(
        string backupPath)
    {
        return File.Exists(
            backupPath);
    }
}