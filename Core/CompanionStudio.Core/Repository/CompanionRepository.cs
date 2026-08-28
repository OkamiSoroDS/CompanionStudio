using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Repository;

public class CompanionRepository
{
    private readonly IProfileStorage storage;


    public CompanionRepository(
        IProfileStorage storage)
    {
        this.storage = storage;
    }


    public void Save(
        CompanionProfile profile)
    {
        storage.Save(profile);
    }


    public CompanionProfile? Load()
    {
        return storage.Load();
    }
}