using System.Text.Json;
using CompanionStudio.Core.Personality;

namespace CompanionStudio.Data.Storage;

public class PersonalityFileStorage : IPersonalityStorage
{
    private readonly string filePath =
        Path.Combine(
            "Files",
            "personalities.json");

    public void Save(IEnumerable<PersonalityModel> personalities)
    {
        Directory.CreateDirectory("Files");

        var json = JsonSerializer.Serialize(
            personalities,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(
            filePath,
            json);
    }

    public IEnumerable<PersonalityModel> Load()
    {
        if (!File.Exists(filePath))
            return new List<PersonalityModel>();

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<PersonalityModel>>(json)
               ?? new List<PersonalityModel>();
    }
}