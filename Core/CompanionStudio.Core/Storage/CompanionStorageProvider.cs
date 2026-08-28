namespace CompanionStudio.Core.Storage;

public class CompanionStorageProvider
{
    private readonly Dictionary<string, string> storage;


    public CompanionStorageProvider()
    {
        storage =
            new Dictionary<string, string>();
    }


    public void Save(
        string key,
        string value)
    {
        storage[key] = value;
    }


    public string? Load(
        string key)
    {
        if (storage.ContainsKey(key))
        {
            return storage[key];
        }

        return null;
    }


    public bool Exists(
        string key)
    {
        return storage.ContainsKey(key);
    }


    public void Delete(
        string key)
    {
        if (storage.ContainsKey(key))
        {
            storage.Remove(key);
        }
    }
}