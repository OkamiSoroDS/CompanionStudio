using CompanionStudio.Core.Identity;

namespace CompanionStudio.Core.Services;

public class IdentityService
{
    private readonly IdentityManager manager;
    private readonly IIdentityStorage storage;

    public IdentityService(IIdentityStorage storage)
    {
        manager = new IdentityManager();
        this.storage = storage;
    }

    public IdentityModel Create(
        string name,
        string description)
    {
        var identity = manager.CreateIdentity(
            name,
            description);

        var identities = storage.Load().ToList();

        identities.Add(identity);

        storage.Save(identities);

        return identity;
    }
}