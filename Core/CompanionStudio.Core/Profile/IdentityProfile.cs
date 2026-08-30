namespace CompanionStudio.Core.Profile;


public class IdentityProfile
{

    // Relación con IdentityModel

    public string IdentityId { get; set; } = string.Empty;



    // ==========================
    // PERSONALITY
    // ==========================

    public string PersonalityType { get; set; } = "Neutral";


    public string CommunicationStyle { get; set; } = "Balanced";


    public string Tone { get; set; } = "Friendly";



    // ==========================
    // CHARACTER TRAITS
    // ==========================

    public List<string> Traits { get; set; } = new();



    // ==========================
    // CORE VALUES
    // ==========================

    public List<string> Values { get; set; } = new();



    // ==========================
    // PREFERENCES
    // ==========================

    public List<string> Preferences { get; set; } = new();



    // ==========================
    // METADATA
    // ==========================

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;


    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

}