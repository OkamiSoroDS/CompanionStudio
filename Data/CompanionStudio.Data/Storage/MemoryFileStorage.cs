using System.Text.Json;
using CompanionStudio.Core.Memory;

namespace CompanionStudio.Data.Storage;

public class MemoryFileStorage : IMemoryStorage
{
    private readonly string filePath =
        Path.Combine(
            "Files",
            "memories.json");

    public void Save(IEnumerable<MemoryModel> memories)
    {
        Directory.CreateDirectory("Files");

        var json = JsonSerializer.Serialize(
            memories,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(
            filePath,
            json);
    }

    public IEnumerable<MemoryModel> Load()
    {
        if (!File.Exists(filePath))
            return new List<MemoryModel>();

        var json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<MemoryModel>>(json)
               ?? new List<MemoryModel>();
    }
}