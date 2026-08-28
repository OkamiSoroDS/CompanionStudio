using CompanionStudio.Core.Identity;

namespace CompanionStudio.Core.Services;

public class IdentityService
{
    private readonly IdentityManager manager;

    public IdentityService()
    {
        manager = new IdentityManager();
    }

    public IdentityModel Create(
        string name,
        string description)
    {
        return manager.CreateIdentity(
            name,
            description);
    }
}