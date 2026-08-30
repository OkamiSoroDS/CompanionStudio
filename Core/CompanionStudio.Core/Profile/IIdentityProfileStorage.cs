using CompanionStudio.Core.Profile;


namespace CompanionStudio.Core.Profile;


public interface IIdentityProfileStorage
{

    void Save(
        IdentityProfile profile);



    IdentityProfile? Load(
        string identityId);



    bool Exists(
        string identityId);



    void Delete(
        string identityId);

}