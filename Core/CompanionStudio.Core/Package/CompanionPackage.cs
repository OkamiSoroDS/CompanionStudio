using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Package;

public class CompanionPackage
{
    public CompanionProfile Profile { get; }

    public string PackageVersion { get; }

    public DateTime CreatedAt { get; }

    public bool Imported { get; private set; }


    public CompanionPackage(
        CompanionProfile profile)
    {
        Profile = profile;

        PackageVersion = "1.0";

        CreatedAt = DateTime.UtcNow;

        Imported = false;
    }


    public void MarkImported()
    {
        Imported = true;
    }
}