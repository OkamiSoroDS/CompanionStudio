using CompanionStudio.Core.Package;
using CompanionStudio.Core.Serialization;

namespace CompanionStudio.Core.Storage;

public class CompanionStorageManager
{
    private readonly PackageSerializer serializer;


    public CompanionStorageManager()
    {
        serializer =
            new PackageSerializer();
    }


    public void Save(
        CompanionPackage package,
        string path)
    {
        var json =
            serializer.Serialize(package);


        File.WriteAllText(
            path,
            json);
    }


    public CompanionPackage? Load(
        string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }


        var json =
            File.ReadAllText(path);


        return serializer.Deserialize(json);
    }


    public void Delete(
        string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}