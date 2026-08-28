namespace CompanionStudio.Core.Personality;

public class PersonalityManager
{
    private int counter = 0;

    public PersonalityModel CreatePersonality(
        string name,
        string tone,
        int humor,
        int curiosity,
        int formality)
    {
        counter++;

        return new PersonalityModel
        {
            Id = $"PER-{counter:D6}",
            Name = name,
            Tone = tone,
            Humor = humor,
            Curiosity = curiosity,
            Formality = formality,
            CreatedAt = DateTime.Now
        };
    }
}