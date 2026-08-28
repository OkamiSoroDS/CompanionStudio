using System.Text.Json;
using CompanionStudio.Core.Identity;

namespace CompanionStudio.Data.Storage;

public class IdentityFileStorage : IIdentityStorage
{
    private readonly string filePath =
        Path.Combine(
            "Files",
            "identities.json"
        );

    public void Save(IEnumerable<IdentityModel> identities)
    {
        var json = JsonSerializer.Serialize(
            identities,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        Directory.CreateDirectory("Files");

        File.WriteAllText(
            filePath,
            json);
    }

    public IEnumerable<IdentityModel> Load()
    {
        if (!File.Exists(filePath))
            return new List<IdentityModel>();

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<IdentityModel>>(json)
               ?? new List<IdentityModel>();
    }
}