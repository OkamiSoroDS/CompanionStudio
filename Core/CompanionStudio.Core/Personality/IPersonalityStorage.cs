namespace CompanionStudio.Core.Personality;

public interface IPersonalityStorage
{
    void Save(IEnumerable<PersonalityModel> personalities);

    IEnumerable<PersonalityModel> Load();
}