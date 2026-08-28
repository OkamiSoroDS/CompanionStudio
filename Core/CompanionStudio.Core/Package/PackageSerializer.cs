using System.Text.Json;
using CompanionStudio.Core.Package;

namespace CompanionStudio.Core.Package;

public class PackageSerializer
{
    public string Serialize(
        CompanionPackage package)
    {
        return JsonSerializer.Serialize(
            package,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });
    }


    public CompanionPackage? Deserialize(
        string json)
    {
        return JsonSerializer.Deserialize<CompanionPackage>(
            json);
    }
}