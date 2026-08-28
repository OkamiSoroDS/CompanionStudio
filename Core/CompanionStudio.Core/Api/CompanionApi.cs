using CompanionStudio.Core.Lifecycle;
using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Api;

public class CompanionApi
{
    private readonly CompanionLifecycleManager lifecycle;


    public CompanionApi()
    {
        lifecycle =
            new CompanionLifecycleManager();
    }


    public void Register(
        CompanionProfile profile)
    {
        lifecycle.Register(profile);
    }


    public bool Start(
        string id)
    {
        return lifecycle.Start(id);
    }


    public void Stop()
    {
        lifecycle.Stop();
    }


    public bool IsRunning()
    {
        return lifecycle.Runtime.IsRunning;
    }
}