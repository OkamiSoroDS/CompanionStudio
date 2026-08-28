namespace CompanionStudio.Core.Personality;

public class PersonalityModel
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Tone { get; set; } = string.Empty;

    public int Humor { get; set; }

    public int Curiosity { get; set; }

    public int Formality { get; set; }

    public DateTime CreatedAt { get; set; }
}
