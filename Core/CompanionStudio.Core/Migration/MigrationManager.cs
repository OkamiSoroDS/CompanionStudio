using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Migration;

public class MigrationManager
{
    public void Migrate(
        CompanionProfile profile,
        string targetVersion)
    {
        if (profile.Version.CurrentVersion
            == targetVersion)
        {
            return;
        }


        profile.Version.CurrentVersion =
            targetVersion;


        profile.Version.LastMigration =
            DateTime.UtcNow;
    }
}