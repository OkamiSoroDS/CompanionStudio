using System.Text.Json;
using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Serialization;

public class CompanionSerializer
{
    public string Serialize(
        CompanionProfile profile)
    {
        return JsonSerializer.Serialize(
            profile,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
    }


    public CompanionProfile? Deserialize(
        string json)
    {
        return JsonSerializer.Deserialize<CompanionProfile>(
            json);
    }
}