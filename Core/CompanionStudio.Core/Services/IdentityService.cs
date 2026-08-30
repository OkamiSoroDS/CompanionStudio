using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Profile;


namespace CompanionStudio.Core.Services;


public class IdentityService
{

    private readonly IdentityManager manager;
    private readonly IIdentityStorage storage;
    private readonly IdentityValidator validator;
    private readonly IdentitySelectorService selectorService;
    private readonly IIdentityProfileStorage profileStorage;



    public IdentityService(
        IIdentityStorage storage,
        IdentitySelectorService selectorService,
        IIdentityProfileStorage profileStorage)
    {

        manager =
            new IdentityManager(storage);


        validator =
            new IdentityValidator();


        this.storage =
            storage;


        this.selectorService =
            selectorService;


        this.profileStorage =
            profileStorage;

    }





    public IdentityModel Create(
        string name,
        string description)
    {

        var identity =
            manager.CreateIdentity(
                name,
                description);




        var identities =
            storage.Load()
            .ToList();




        // Desactivar identidades anteriores

        foreach (var item in identities)
        {
            item.IsActive = false;
        }




        identity.IsActive = true;



        identities.Add(identity);



        storage.Save(
            identities);





        // ==========================
        // CREATE INITIAL PROFILE
        // ==========================


        var profile =
            new IdentityProfile
            {
                IdentityId = identity.Id,

                PersonalityType = "Neutral",

                CommunicationStyle = "Balanced",

                Tone = "Friendly"
            };



        profile.Traits.Add(
            "Curious");


        profile.Values.Add(
            "Trust");



        profileStorage.Save(
            profile);





        // Guardar identidad activa

        selectorService
            .SetActiveIdentity(
                identity.Id);




        return identity;

    }





    public IdentityModel? GetCurrentIdentity()
    {

        return selectorService
            .GetActiveIdentity();

    }





    public IEnumerable<IdentityModel> GetAll()
    {

        return storage.Load();

    }





    public bool ValidateIdentity(
        IdentityModel identity)
    {

        return validator
            .Validate(identity);

    }

}