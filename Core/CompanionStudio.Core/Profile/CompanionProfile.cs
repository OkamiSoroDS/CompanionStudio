using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Personality;

namespace CompanionStudio.Core.Profile;

public class CompanionProfile
{
    public IdentityModel Identity { get; }

    public PersonalityModel Personality { get; }

    public List<MemoryModel> Memories { get; }

    public string IntegrityHash { get; set; } = string.Empty;


    public CompanionProfile(
        IdentityModel identity,
        PersonalityModel personality)
    {
        Identity = identity;
        Personality = personality;
        Memories = new List<MemoryModel>();
    }


    public void AddMemory(
        MemoryModel memory)
    {
        Memories.Add(memory);
    }
}