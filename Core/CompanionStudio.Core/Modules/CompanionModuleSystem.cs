namespace CompanionStudio.Core.Modules;

public class CompanionModuleSystem
{
    private readonly List<CompanionModule> modules;


    public CompanionModuleSystem()
    {
        modules = new List<CompanionModule>();
    }


    public void Register(
        CompanionModule module)
    {
        modules.Add(module);
    }


    public CompanionModule? Find(
        string id)
    {
        return modules
            .FirstOrDefault(
                x => x.Id == id);
    }


    public IReadOnlyList<CompanionModule> GetAll()
    {
        return modules;
    }
}