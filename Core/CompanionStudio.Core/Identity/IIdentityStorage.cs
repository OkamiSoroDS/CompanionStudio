using System.Collections.Generic;


namespace CompanionStudio.Core.Identity;


public interface IIdentityStorage
{

    List<IdentityModel> Load();



    void Save(
        IEnumerable<IdentityModel> identities);



    void SaveActiveIdentity(
        string identityId);



    string? LoadActiveIdentity();

}