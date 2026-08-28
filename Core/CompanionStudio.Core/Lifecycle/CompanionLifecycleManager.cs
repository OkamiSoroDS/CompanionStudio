using CompanionStudio.Core.Backup;
using CompanionStudio.Core.Health;
using CompanionStudio.Core.Registry;
using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Storage;
using CompanionStudio.Core.Package;
using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Lifecycle;

public class CompanionLifecycleManager
{
    public CompanionRegistry Registry { get; }

    public CompanionRuntime Runtime { get; }

    public CompanionStorageManager Storage { get; }

    public CompanionBackupManager Backup { get; }

    public CompanionHealthMonitor Health { get; }


    public CompanionLifecycleManager()
    {
        Registry =
            new CompanionRegistry();

        Runtime =
            new CompanionRuntime();

        Storage =
            new CompanionStorageManager();

        Backup =
            new CompanionBackupManager();

        Health =
            new CompanionHealthMonitor();
    }


    public void Register(
        CompanionProfile profile)
    {
        Registry.Register(profile);
    }


    public bool Start(
        string id)
    {
        var companion =
            Registry.Find(id);


        if (companion == null)
        {
            return false;
        }


        if (!Health.IsHealthy(companion))
        {
            return false;
        }


        Runtime.Start(companion);

        return true;
    }


    public void Stop()
    {
        Runtime.Stop();
    }
}