namespace CompanionStudio.Core.Identity;

public class IdentityManager
{
    private readonly List<IdentityModel> identities = new();

    public IdentityModel CreateIdentity(string name, string description)
    {
        var identity = new IdentityModel
        {
            Id = $"CS-{identities.Count + 1:000000}",
            Name = name,
            Description = description
        };

        identities.Add(identity);

        return identity;
    }

    public IEnumerable<IdentityModel> GetIdentities()
    {
        return identities;
    }
}