using CompanionStudio.Core.Identity;

namespace CompanionStudio.Core.Services;

public class IdentitySelectorService
{
    private readonly IIdentityStorage storage;


    public IdentitySelectorService(
        IIdentityStorage storage)
    {
        this.storage = storage;
    }


    public void SetActiveIdentity(
        string identityId)
    {
        storage.SaveActiveIdentity(identityId);
    }


    public IdentityModel? GetActiveIdentity()
    {
        var activeId =
            storage.LoadActiveIdentity();


        if (string.IsNullOrWhiteSpace(activeId))
            return null;


        return storage
            .Load()
            .FirstOrDefault(x =>
                x.Id == activeId);
    }


    public IEnumerable<IdentityModel> GetAvailableIdentities()
    {
        return storage.Load();
    }
}