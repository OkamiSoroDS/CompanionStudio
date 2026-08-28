using CompanionStudio.Core.Personality;

namespace CompanionStudio.Core.Services;

public class PersonalityService
{
    private readonly PersonalityManager manager;
    private readonly IPersonalityStorage storage;

    public PersonalityService(IPersonalityStorage storage)
    {
        manager = new PersonalityManager();
        this.storage = storage;
    }

    public PersonalityModel Create(
        string name,
        string tone,
        int humor,
        int curiosity,
        int formality)
    {
        var personality = manager.CreatePersonality(
            name,
            tone,
            humor,
            curiosity,
            formality);

        var personalities = storage.Load().ToList();

        personalities.Add(personality);

        storage.Save(personalities);

        return personality;
    }
}