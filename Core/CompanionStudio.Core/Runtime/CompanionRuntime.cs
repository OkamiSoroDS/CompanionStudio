using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Runtime;

public class CompanionRuntime
{
    public CompanionProfile? ActiveCompanion { get; private set; }


    public bool IsRunning =>
        ActiveCompanion != null;


    public void Start(
        CompanionProfile profile)
    {
        ActiveCompanion = profile;

        ActiveCompanion.State.IsActive = true;
        ActiveCompanion.State.LastLoaded = DateTime.UtcNow;
        ActiveCompanion.State.Status = "Running";
    }


    public void Stop()
    {
        if (ActiveCompanion == null)
        {
            return;
        }


        ActiveCompanion.State.IsActive = false;
        ActiveCompanion.State.Status = "Stopped";

        ActiveCompanion = null;
    }
}