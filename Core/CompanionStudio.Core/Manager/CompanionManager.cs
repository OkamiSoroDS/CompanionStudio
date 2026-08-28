using CompanionStudio.Core.Factory;
using CompanionStudio.Core.Profile;
using CompanionStudio.Core.Repository;
using CompanionStudio.Core.Security;

namespace CompanionStudio.Core.Manager;

public class CompanionManager
{
    private readonly CompanionFactory factory;
    private readonly CompanionRepository repository;
    private readonly ProfileIntegrityService integrityService;


    public CompanionManager(
        CompanionFactory factory,
        CompanionRepository repository,
        ProfileIntegrityService integrityService)
    {
        this.factory = factory;
        this.repository = repository;
        this.integrityService = integrityService;
    }


    public CompanionProfile Create(
        string name,
        string description,
        string tone,
        int humor,
        int curiosity,
        int formality)
    {
        var profile =
            factory.Create(
                name,
                description,
                tone,
                humor,
                curiosity,
                formality);


        repository.Save(profile);


        return profile;
    }


    public CompanionProfile? Load()
    {
        return repository.Load();
    }


    public bool Verify(
        CompanionProfile profile)
    {
        return integrityService.Verify(profile);
    }
}