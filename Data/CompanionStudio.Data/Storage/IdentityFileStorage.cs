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

        using (var stream = new FileStream(
            filePath,
            FileMode.Create,
            FileAccess.Write,
            FileShare.Read))
        {
            using var writer = new StreamWriter(stream);

            writer.Write(json);
        }
    }

    public IEnumerable<IdentityModel> Load()
    {
        if (!File.Exists(filePath))
            return new List<IdentityModel>();

        string json;

        using (var stream = new FileStream(
            filePath,
            FileMode.Open,
            FileAccess.Read,
            FileShare.ReadWrite))
        {
            using var reader = new StreamReader(stream);

            json = reader.ReadToEnd();
        }

        return JsonSerializer.Deserialize<List<IdentityModel>>(json)
               ?? new List<IdentityModel>();
    }
}