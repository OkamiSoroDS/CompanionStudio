namespace CompanionStudio.Core.Permissions;

public class CompanionPermissionSystem
{
    private readonly List<CompanionPermission> permissions;


    public CompanionPermissionSystem()
    {
        permissions =
            new List<CompanionPermission>();
    }


    public void Grant(
        CompanionPermission permission)
    {
        permissions.Add(permission);
    }


    public bool HasPermission(
        string id)
    {
        return permissions
            .Any(x => x.Id == id);
    }


    public void Revoke(
        string id)
    {
        var permission =
            permissions
            .FirstOrDefault(
                x => x.Id == id);


        if (permission != null)
        {
            permissions.Remove(permission);
        }
    }


    public IReadOnlyList<CompanionPermission> GetAll()
    {
        return permissions;
    }
}