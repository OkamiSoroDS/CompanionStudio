using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Security;

namespace CompanionStudio.Core.Factory;

public class CompanionFactory
{
    private readonly IdentityManager identityManager;
    private readonly PersonalityManager personalityManager;
    private readonly ProfileIntegrityService integrityService;


    public CompanionFactory()
    {
        identityManager = new IdentityManager();

        personalityManager = new PersonalityManager();

        integrityService = new ProfileIntegrityService();
    }


    public CompanionProfile Create(
        string name,
        string description,
        string tone,
        int humor,
        int curiosity,
        int formality)
    {
        var identity =
            identityManager.CreateIdentity(
                name,
                description);


        var personality =
            personalityManager.CreatePersonality(
                name,
                tone,
                humor,
                curiosity,
                formality);


        var profile =
            new CompanionProfile(
                identity,
                personality);


        integrityService.GenerateHash(
            profile);


        return profile;
    }
}