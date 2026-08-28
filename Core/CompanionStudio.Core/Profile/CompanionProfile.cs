using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Personality;
using CompanionStudio.Core.State;

namespace CompanionStudio.Core.Profile;

public class CompanionProfile
{
    public IdentityModel Identity { get; }

    public PersonalityModel Personality { get; }

    public List<MemoryModel> Memories { get; }

    public string IntegrityHash { get; set; } = string.Empty;

    public CompanionState State { get; }

    public CompanionProfile(
    IdentityModel identity,
    PersonalityModel personality)
    {
        Identity = identity;
        Personality = personality;

        Memories = new List<MemoryModel>();

        State = new CompanionState
        {
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            LastLoaded = DateTime.UtcNow,
            Version = "1.0",
            Status = "Created"
        };
    }


    public void AddMemory(
        MemoryModel memory)
    {
        Memories.Add(memory);
    }
}