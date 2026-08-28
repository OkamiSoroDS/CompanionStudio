namespace CompanionStudio.Core.Identity;

public interface IIdentityStorage
{
    void Save(IEnumerable<IdentityModel> identities);

    IEnumerable<IdentityModel> Load();
}