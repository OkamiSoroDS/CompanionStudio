using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Runtime;
using CompanionStudio.Core.Services;
using CompanionStudio.Core.Identity;

namespace CompanionStudio.App.UI.Services;

public class CompanionUIService
{
    private readonly CompanionRuntime _runtime;
    private readonly IdentityService _identityService;


    public CompanionUIService(
        IdentityService identityService)
    {
        _runtime = new CompanionRuntime();
        _identityService = identityService;
    }


    public CompanionProfile? GetCurrentCompanion()
    {
        return _runtime.ActiveCompanion;
    }


    public string GetCurrentStatus()
    {
        if (_runtime.IsRunning)
        {
            return "Running";
        }

        return "Offline";
    }


    public IdentityModel? GetCurrentIdentity()
    {
        return _identityService.GetCurrentIdentity();
    }


    public bool ValidateIdentity(
        IdentityModel identity)
    {
        return _identityService.ValidateIdentity(identity);
    }
}