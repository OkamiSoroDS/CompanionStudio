using CompanionStudio.Core.Identity;
using CompanionStudio.Core.Memory;
using CompanionStudio.Core.Personality;

namespace CompanionStudio.Core.Engine;

public class CompanionEngine
{
    public IdentityModel Identity { get; }

    public List<MemoryModel> Memories { get; }

    public PersonalityModel Personality { get; }


    public CompanionEngine(
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