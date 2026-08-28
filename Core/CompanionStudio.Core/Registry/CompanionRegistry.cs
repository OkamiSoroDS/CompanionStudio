using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Registry;

public class CompanionRegistry
{
    private readonly List<CompanionProfile> companions;


    public CompanionRegistry()
    {
        companions = new List<CompanionProfile>();
    }


    public void Register(
        CompanionProfile profile)
    {
        companions.Add(profile);
    }


    public CompanionProfile? Find(
        string id)
    {
        return companions
            .FirstOrDefault(
                x => x.Identity.Id == id);
    }


    public IReadOnlyList<CompanionProfile> List()
    {
        return companions;
    }


    public bool Remove(
        string id)
    {
        var companion =
            Find(id);


        if (companion == null)
        {
            return false;
        }


        return companions.Remove(
            companion);
    }
}