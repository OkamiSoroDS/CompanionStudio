using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Health;

public class CompanionHealthMonitor
{
    public bool CheckIdentity(
        CompanionProfile profile)
    {
        return profile.Identity != null
            && !string.IsNullOrEmpty(
                profile.Identity.Id);
    }


    public bool CheckState(
        CompanionProfile profile)
    {
        return profile.State != null;
    }


    public bool CheckVersion(
        CompanionProfile profile)
    {
        return profile.Version != null
            && !string.IsNullOrEmpty(
                profile.Version.CurrentVersion);
    }


    public bool IsHealthy(
        CompanionProfile profile)
    {
        return CheckIdentity(profile)
            && CheckState(profile)
            && CheckVersion(profile);
    }
}