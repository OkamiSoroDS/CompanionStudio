using CompanionStudio.Core.Profile;

namespace CompanionStudio.Core.Package;

public class CompanionPackageSystem
{
    private readonly List<CompanionPackage> packages;


    public CompanionPackageSystem()
    {
        packages =
            new List<CompanionPackage>();
    }


    public void Export(
        CompanionPackage package)
    {
        packages.Add(package);
    }


    public CompanionPackage? Find(
        CompanionProfile profile)
    {
        return packages
            .FirstOrDefault(
                x => x.Profile == profile);
    }


    public void Import(
        CompanionProfile profile)
    {
        var package =
            Find(profile);


        if (package != null)
        {
            package.MarkImported();
        }
    }


    public IReadOnlyList<CompanionPackage> GetAll()
    {
        return packages;
    }
}