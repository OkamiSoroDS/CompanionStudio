using System.Text.Json;
using CompanionStudio.Core.Profile;

namespace CompanionStudio.Data.Storage;

public class CompanionProfileFileStorage : IProfileStorage
{
    private readonly string filePath;


    public CompanionProfileFileStorage(
        string? customPath = null)
    {
        filePath = customPath ??
            Path.Combine(
                "Files",
                "companion.json");
    }


    public void Save(
        CompanionProfile profile)
    {
        var directory =
            Path.GetDirectoryName(filePath);

        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }


        var json = JsonSerializer.Serialize(
            profile,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });


        File.WriteAllText(
            filePath,
            json);
    }


    public CompanionProfile? Load()
    {
        if (!File.Exists(filePath))
            return null;


        var json = File.ReadAllText(
            filePath);


        if (string.IsNullOrWhiteSpace(json))
            return null;


        return JsonSerializer.Deserialize<CompanionProfile>(
    json,
    new JsonSerializerOptions
    {
        WriteIndented = true
    });
    }
}