namespace CompanionStudio.Core.Modules;

public class CompanionModule
{
    public string Id { get; }

    public string Name { get; }

    public bool Enabled { get; private set; }


    public CompanionModule(
        string id,
        string name)
    {
        Id = id;
        Name = name;
        Enabled = false;
    }


    public void Enable()
    {
        Enabled = true;
    }


    public void Disable()
    {
        Enabled = false;
    }
}