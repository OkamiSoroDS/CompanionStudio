namespace CompanionStudio.Core.Plugins;

public class CompanionPluginSystem
{
    private readonly List<CompanionPlugin> plugins;


    public CompanionPluginSystem()
    {
        plugins =
            new List<CompanionPlugin>();
    }


    public void Register(
        CompanionPlugin plugin)
    {
        plugins.Add(plugin);
    }


    public CompanionPlugin? Find(
        string id)
    {
        return plugins
            .FirstOrDefault(
                x => x.Id == id);
    }


    public IReadOnlyList<CompanionPlugin> GetAll()
    {
        return plugins;
    }
}