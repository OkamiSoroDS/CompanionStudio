using System.Text.Json;
using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Security;

public class ProfileIntegrityService
{
    private readonly IntegrityChecker checker;

    public ProfileIntegrityService()
    {
        checker = new IntegrityChecker();
    }


    public string GenerateHash(
        CompanionProfile profile)
    {
        var data = JsonSerializer.Serialize(
            new
            {
                profile.Identity,
                profile.Personality,
                profile.Memories
            });

        var hash = checker.CreateHash(data);

        profile.IntegrityHash = hash;

        return hash;
    }


    public bool Verify(
        CompanionProfile profile)
    {
        var data = JsonSerializer.Serialize(
            new
            {
                profile.Identity,
                profile.Personality,
                profile.Memories
            });

        return checker.Verify(
            data,
            profile.IntegrityHash);
    }
}