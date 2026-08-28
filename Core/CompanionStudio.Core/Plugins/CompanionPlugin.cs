namespace CompanionStudio.Core.Plugins;

public class CompanionPlugin
{
    public string Id { get; }

    public string Name { get; }

    public bool Loaded { get; private set; }


    public CompanionPlugin(
        string id,
        string name)
    {
        Id = id;
        Name = name;
        Loaded = false;
    }


    public void Load()
    {
        Loaded = true;
    }


    public void Unload()
    {
        Loaded = false;
    }
}